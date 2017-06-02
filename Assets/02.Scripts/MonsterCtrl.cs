using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour {
    

	public enum MonsterState {
		idle, trace, attack, die
	};
	public MonsterState monsterState = MonsterState.idle;
    
	public float hp = 10.0f;
	public float traceDist = 20.0f;
	public float attackDist = 2.0f;

    public int GunDamage = 5;
    public int GunHeadDamage = 15;
    public int GunPoint = 20;
    public int GunHeadPoint = 100;
    public int GunUlti = 10;
    public int GunHeadUlti = 20;

    public bool wasShot = false;
	private bool isDie = false;
    private bool isHit = false;

	private Transform monsterTr;
	private Transform playerTr;
	private NavMeshAgent nvAgent;
	private Animator animator;

	private InGameUI gameUI;

	void Start () {
		monsterTr = this.gameObject.GetComponent<Transform> ();
		playerTr = GameObject.FindWithTag ("Player").GetComponent<Transform> ();
		nvAgent = this.gameObject.GetComponent<NavMeshAgent> ();
		nvAgent.destination = playerTr.position;

		animator = this.gameObject.GetComponent<Animator> ();
	
		StartCoroutine (this.CheckMonsterState ());
		StartCoroutine (this.MonsterAction ());

		gameUI = GameObject.Find ("InGameUI").GetComponent<InGameUI> ();
	}

	IEnumerator CheckMonsterState()
	{
		while (!isDie)
		{
			yield return new WaitForSeconds (0.1f);
			float dist = Vector3.Distance (playerTr.position, monsterTr.position);

            if (dist <= attackDist)
            {
                monsterState = MonsterState.attack;
            }
            else if (dist <= traceDist)
            {
                monsterState = MonsterState.trace;
            }
            else if (isHit && dist > attackDist) {
                monsterState = MonsterState.trace;
            }
			else {
				monsterState = MonsterState.idle;
			}
		}
	}

	IEnumerator MonsterAction()
	{
		while (!isDie)
		{
			switch (monsterState){
				case MonsterState.idle:
					nvAgent.Stop ();
					animator.SetBool ("IsTrace", false);
				break;
				case MonsterState.trace:
					nvAgent.destination = playerTr.position;
					nvAgent.Resume ();
					animator.SetBool ("IsAttack", false);
					animator.SetBool ("IsTrace", true);
				break;
                case MonsterState.attack:
                    nvAgent.Stop();
                    animator.SetBool("IsAttack", true);
				break;
			}
			yield return null;	
		}
	}

    void OnDamage(object[] _params)
    {	
        isHit = true;
		animator.SetTrigger("IsHit");
        Debug.Log("Hit!");
        if (((bool)_params[1]) == true)//headshot
        {   
            hp -= GunHeadDamage;
            gameUI.DispUlti(GunHeadUlti, false);    
            if (wasShot == false)//initial headshot
            {
                gameUI.DispScore(GunHeadPoint);
            }
            else//headshot but not initial
            {
                gameUI.DispScore(GunPoint);
            }
        }
        else//not headshot
        {
            hp -= GunDamage;
            gameUI.DispScore(GunPoint);
            gameUI.DispUlti(GunUlti, false);
        }

        wasShot = true;

        if (hp <= 0.0f)
        {
            MonsterDie();
            Debug.Log("Dead!");
        }
    }

	void MonsterDie(){
		StopAllCoroutines ();
		isDie = true;
		monsterState = MonsterState.die;
		nvAgent.Stop ();
		animator.SetTrigger ("IsDie");
        gameObject.gameObject.GetComponentInChildren<BoxCollider> ().enabled = false;

		foreach (Collider coll in gameObject.GetComponentsInChildren<BoxCollider>()) {
			coll.enabled = false;
		}
		Destroy (gameObject, 2);
        gameUI.DispKill(1);
        gameUI.DispCount (-1);
  
	}

    void Attack() {
        Debug.Log("Attack");
    }
}
