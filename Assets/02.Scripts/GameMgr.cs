using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using CnControls;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class GameMgr : MonoBehaviour {
    public Transform[] points;
    public GameObject monsterPrefab;
    public float createTime = 2.0f;
    public int maxMonster = 20;
    public bool isGameOver = false;
    public bool isWin = false;
    public bool isLose = false;
    public bool ultiOn = false;
    public static GameMgr instance = null;
    private float Interval = 1.0f;
    private float nextTime = 0.0f;
    private InGameUI gameUI;
    public Image fireButton;
    public GameObject GameOverUI;
    public bool isGame = false;
    public int highScore = 0;
    public Text Score;
    public int headShotCount = 0;
    public bool puzzle1c = false;
    public bool puzzle1d = false;
    
    void Awake ()
    {
        instance = this;
    }

    // Use this for initialization
    void Start() {
        if (GameObject.Find("MonsterSpawnPoint")) {
            points = GameObject.Find("MonsterSpawnPoint").GetComponentsInChildren<Transform>();
            isGame = true;
            highScore = PlayerPrefs.GetInt("HIGH_SCORE");
        }
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

        if (isGameOver)
        {
            GameOverUI.SetActive(true);
            Score.text = "HIGHSCORE" + highScore.ToString();
        }
        
        if (Input.GetKeyDown("escape") || CnControls.CnInputManager.GetButtonDown("Escape"))
        {
            PlayerPrefs.Save();
            Application.Quit();
        }
        KillCountCheck();
        UltiCheck();

        if(Time.time > nextTime){
            nextTime = Time.time + Interval;
            TimeCheck();
        }
    }

    public void button_Restart() {
        //LoadingScreenManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void button_MainMenu() 
    {
        SceneManager.LoadScene(1);

        //LoadingScreenManager.LoadScene(1);
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

    void TimeCheck()
    {
        gameUI.DispTime(1);
        if (gameUI.timeLeft == 0)
        {
            Debug.Log("survived!");
            isWin = true;
            isGameOver = true;
        }
    }

    void UltiCheck()
    {
        if ( (gameUI.ulti >= gameUI.maxUlti) && ultiOn == false )
        {
            Debug.Log("Ulti on");
            ultiOn = true;
            fireButton.color = Color.green;
        }
    }
}
