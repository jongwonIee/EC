using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour {
    public Transform[] points;
    public GameObject monsterPrefab;
    public float createTime = 2.0f;
    public int maxMonster = 10;
    public bool isGameOver = false;
    public static GameMgr instance = null;

    void Awake ()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
        points = GameObject.Find("MonsterSpawnPoint").GetComponentsInChildren<Transform>();

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

            if (monsterCount < maxMonster)
            {
                yield return new WaitForSeconds(createTime);

                int idx = Random.Range(1, points.Length);
                Instantiate(monsterPrefab, points[idx].position, points[idx].rotation);
            }
            else
            {
                yield return null;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape"))
            Application.Quit();
	}
}
