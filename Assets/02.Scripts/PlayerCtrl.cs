using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCtrl : MonoBehaviour {
    public int hp = 100;
    private int initHp;
    public Image imgHpbar;
    public GameMgr gameMgr;
    private Transform tr;
    private InGameUI gameUI;
  
    void Start(){
        initHp = hp;

        tr = GetComponent<Transform>();

        gameMgr = GameObject.Find ("GameManager").GetComponent<GameMgr> ();
        gameUI = GameObject.Find ("InGameUI").GetComponent<InGameUI> ();

    }

    void Update(){
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "PUNCH")
        {
            hp -= 10;
            imgHpbar.fillAmount = (float)hp / (float)initHp;
            gameUI.DispUlti(-10, false);
            Debug.Log(hp);
        }

        if (hp <= 0)
        {
            PlayerDie();
        }
    }

    void PlayerDie()
    {
        Debug.Log("Player Die!!");
        OnPlayerDie();
        GameMgr.instance.isGameOver = true;
    }

    void OnPlayerDie()
    {
        Debug.Log("HP 0 Lose");
        gameMgr.isLose = true;
        gameMgr.isGameOver = true;
    }
}
