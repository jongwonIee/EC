using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InGameUI : MonoBehaviour {
	
    public float ActionRange;
    public float FireRange;
    public float TargetDistance;
    public Transform firePos;
    public Text txtScore;
    public Text txtCount;
    public Text txtHighScore;
    public Text txtKillCount;
    public RawImage aimPoint;
    public RawImage aimPointCenter;
	public int totScore = 0;
    public int totCount = 0;
    public int highScore = 0;
    public int killCount = 0;
	public int totMonster1 = 0;
	public int totMonster2 = 0;
	public int totMonster3 = 0;
    public int maxMonster = 0;
    public int objMonster = 10;
    public GunFire gunFire;
    public PlayerCasting playerCasting;

    private GameMgr gameMgr;


	// Use this for initialization
	void Start () {
        highScore = PlayerPrefs.GetInt ("HIGH_SCORE");
        FireRange = gunFire.Range;
        ActionRange = playerCasting.Range;
        gameMgr = GameObject.Find ("GameManager").GetComponent<GameMgr> ();
        DispScore (0);
        DispHighScore(0);
        DispCount (0);
        DispKill(0);
	}

	public void DispScore(int score)
	{
		totScore += score;
        txtScore.text = "SCORE  : " + totScore.ToString();
        if (highScore < totScore)
        {
            PlayerPrefs.SetInt("HIGH_SCORE", totScore);
        }
	}

    public void DispCount(int count)
    {   
        maxMonster = gameMgr.maxMonster;
        totCount += count;
        txtCount.text = "OVERFLOW : " + totCount.ToString() + "/" + maxMonster.ToString();        
    }

    public void DispHighScore(int score)
    {
        highScore += score;
        txtHighScore.text = "HIGHSCORE : " + highScore.ToString();
    }

    public void DispKill(int kill)
    {
        killCount += kill;
        txtKillCount.text = "KILL : " + killCount.ToString() + "/" + objMonster.ToString();
    }

    void Update (){
        RaycastHit hit;
        if (Physics.Raycast (firePos.position, firePos.TransformDirection(Vector3.forward), out hit))
        {
            TargetDistance = hit.distance;
            if (TargetDistance < FireRange && hit.collider.tag == "MONSTER" || hit.collider.tag == "HEAD")
            {
                aimPoint.color = Color.red;
                aimPointCenter.color = Color.red;
            }
            else if (TargetDistance < ActionRange && hit.collider.tag == "OBJECT")
            {
                aimPoint.color = Color.green;
                aimPointCenter.color = Color.green;
            }   
            else
            {
                aimPoint.color = Color.white;
                aimPointCenter.color = Color.white; 
            }
        }
    }
}
