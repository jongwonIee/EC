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

	private bool isDie = false;

	private Transform monsterTr;
	private Transform playerTr;
	private NavMeshAgent nvAgent;
	private Animator animator;

	private InGameUI gameUI;

	// Use this for initialization
	void Start () {
		monsterTr = this.gameObject.GetComponent<Transform> ();
		//slow so not in update func
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
			yield return new WaitForSeconds (0.02f);
			float dist = Vector3.Distance (playerTr.position, monsterTr.position);

			if (dist <= attackDist) {
				monsterState = MonsterState.attack;
			}
			else if (dist <= traceDist) {
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
//                    monsterTr.LookAt(playerTr.position);
                    //오차 나면  slerp
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
		animator.SetTrigger("IsHit");
        Debug.Log("Hit!");
        hp -= (int) _params[1];
        gameUI.DispScore ((int) _params[2]);
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
        gameUI.DispScore (50);
		Destroy (gameObject, 2);
	}

    void Attack() {
        Debug.Log("Attack");
    }
}
