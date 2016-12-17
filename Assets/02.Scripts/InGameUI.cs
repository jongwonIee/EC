using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour {
	
    public float Range = 5.0f;
    public float TargetDistance;
    public Transform firePos;
    public Text txtScore;
    public RawImage aimPoint;
    public RawImage aimPointCenter;
	public int totScore = 0;
	public int totMonster1 = 0;
	public int totMonster2 = 0;
	public int totMonster3 = 0;

	// Use this for initialization
	void Start () {
		totScore = PlayerPrefs.GetInt ("TOT_SCORE", 0);
   //     firePos = GameObject.FindGameObjectWithTag("Player").transform;
        DispScore (0);	
	}

	public void DispScore(int score)
	{
		totScore += score;
		txtScore.text = "SCORE  : " + totScore.ToString () + " " + "AREA1  : 6 AREA2 : 3 AREA3 : 9";
	

		PlayerPrefs.SetInt("TOT_SOCRE", totScore);
	}

    void Update (){
        RaycastHit hit;

        if (Physics.Raycast (firePos.position, firePos.TransformDirection(Vector3.forward), out hit))
        {
            TargetDistance = hit.distance;
            if (TargetDistance < Range && hit.collider.tag == "MONSTER")
            {
                aimPoint.color = Color.red;
                aimPointCenter.color = Color.red;
            }
            else if (TargetDistance < Range && hit.collider.tag == "OBJECT")
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
