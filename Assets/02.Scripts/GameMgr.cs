using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class GameMgr : MonoBehaviour {
    public Transform[] points;
    public GameObject monsterPrefab;
    public float createTime = 2.0f;
    public int maxMonster = 20;
    public bool isGameOver = false;
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
                isGameOver = true;
                Debug.Log("aaaaa");
            }
        }
    }

    public void button_Restart() {
        Time.timeScale = 1;
        //LoadingScreenManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void button_MainMenu() 
       {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);

        //LoadingScreenManager.LoadScene(1);
    }
    public GameObject GameOverUI;
    // Update is called once per frame
    void Update () {
        if (isGameOver) {
            Time.timeScale = 0;
            GameOverUI.SetActive(true);
        }
        if (Input.GetKeyDown("escape") || CnControls.CnInputManager.GetButtonDown("Escape")) {
            PlayerPrefs.Save();
            Application.Quit();
        }
	}
}
