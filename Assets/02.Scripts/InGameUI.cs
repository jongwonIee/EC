using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour {
	
	public Text txtScore;
	public int totScore = 0;
	public int totMonster1 = 0;
	public int totMonster2 = 0;
	public int totMonster3 = 0;

	// Use this for initialization
	void Start () {
		totScore = PlayerPrefs.GetInt ("TOT_SCORE", 0);
		DispScore (0);	
	}

	public void DispScore(int score)
	{
		totScore += score;
		txtScore.text = "SCORE  : " + totScore.ToString () + " " + "AREA1  : 6 AREA2 : 3 AREA3 : 9";
	

		PlayerPrefs.SetInt("TOT_SOCRE", totScore);
	}
}
