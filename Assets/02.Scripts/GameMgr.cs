using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour {
    public Transform[] points;
    public GameObject monsterPrefab;
    public float createTime = 2.0f;
    public int maxMonster = 20;
    public bool isGameOver = false;
    public bool isWin = false;
    public bool isLose = false;
    public static GameMgr instance = null;
    private InGameUI gameUI;

    void Awake ()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {

        points = GameObject.Find("MonsterSpawnPoint").GetComponentsInChildren<Transform>();
        gameUI = GameObject.Find ("InGameUI").GetComponent<InGameUI> ();

        if (points.Length > 0)
        {
            StartCoroutine(this.CreateMonster());
        }

	}

    IEnumerator CreateMonster()
    {
        while (!isGameOver)
        {
            int monsterCount = (int)GameObject.FindGameObjectsWithTag("MONSTER").Length;

            if (monsterCount <= maxMonster)
            {
                yield return new WaitForSeconds(createTime);
                gameUI.DispCount (1);
                int idx = Random.Range(1, points.Length);
                Instantiate(monsterPrefab, points[idx].position, points[idx].rotation);
            }
            else
            {
                Debug.Log("OverFlow Lose");
                isLose = true;
                isGameOver = true;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown("escape") || CnControls.CnInputManager.GetButtonDown("Escape"))
        {
            PlayerPrefs.Save();
            Application.Quit();
        }
        KillCountCheck();
	}

    void KillCountCheck ()
    {
        if (gameUI.killCount >= gameUI.objMonster)
        {
            Debug.Log("killed all");
            isWin = true;
            isGameOver = true;
        }
    }
}
