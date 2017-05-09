using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCtrl : MonoBehaviour {
    public int hp = 100;
    private int initHp;
    public Image imgHpbar;
    private Transform tr;
  
    void Start(){
        initHp = hp;

        tr = GetComponent<Transform>();

    }
    void Update(){
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "PUNCH")
        {
            hp -= 10;
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
        Debug.Log("Game End!!");
    }
}
