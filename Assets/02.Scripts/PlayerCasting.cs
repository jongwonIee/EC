﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerCasting : MonoBehaviour {
    
    public float Range = 5.0f;
    public float TargetDistance;
    public Transform firePos;
    public GameObject lightObject;
    public GameObject puzzleA;
    public GameObject puzzleB;
    public GameObject puzzleC;
    public GameObject puzzleH;
    public int puzzleCount = 0;
    public GameMgr gameMgr;

    void Start () {
        gameMgr = GameObject.Find ("GameManager").GetComponent<GameMgr> ();
    }

    void Update () {
        RaycastHit hit;
        if (CnControls.CnInputManager.GetButtonDown("Action"))
        {

            if (Physics.Raycast (firePos.position, firePos.TransformDirection(Vector3.forward), out hit))
            {
                TargetDistance = hit.distance;

                if (TargetDistance < Range && hit.collider.tag == "OBJECT")
                {
                    lightObject = hit.transform.Find("lightObject").gameObject;
                    lightObject.SetActive(false);
                    hit.collider.tag = "Untagged";
                    puzzleCount += 1;
                }
            }
        }
        if (!(PlayerPrefs.GetInt("puzzle_1_1_a") == 1)){
            CheckPuzzleCount_1_1_A();
        }
        else {
            puzzleA.SetActive(true);
        }

        if (!(PlayerPrefs.GetInt("puzzle_1_1_b") == 1)){
            CheckPuzzleCount_1_1_B();
        }
        else
        {
            puzzleB.SetActive(true);
        }

        if (!(PlayerPrefs.GetInt("puzzle_1_1_c") == 1)){
            CheckPuzzleCount_1_1_C();
        }
        else
        {
            puzzleC.SetActive(true);
        }

        if (!(PlayerPrefs.GetInt("puzzle_1_1_h") == 1)){
            CheckPuzzleCount_1_1_H();
        }
        else
        {
            puzzleH.SetActive(true);
        }
    }

    void CheckPuzzleCount_1_1_A()
    {
        if (puzzleCount == 3)
        {
            puzzleA.SetActive(true);
            PlayerPrefs.SetInt("puzzle_1_1_a", 1);
        }
    }

    void CheckPuzzleCount_1_1_B()
    {
        if (gameMgr.headShotCount == 3)
        {
            puzzleB.SetActive(true);
            PlayerPrefs.SetInt("puzzle_1_1_b", 1);
        }
    }

    void CheckPuzzleCount_1_1_C()
    {
        int monsterCount = (int)GameObject.FindGameObjectsWithTag("MONSTER").Length;
        if (gameMgr.puzzle1c == true)
        {
            puzzleC.SetActive(true);
            PlayerPrefs.SetInt("puzzle_1_1_c", 1);
        }
    }

    void CheckPuzzleCount_1_1_H()
    {
        if ( (PlayerPrefs.GetInt("puzzle_1_1_a") == 1) && (PlayerPrefs.GetInt("puzzle_1_1_b") == 1) && (PlayerPrefs.GetInt("puzzle_1_1_c") == 1) )
        {
            PlayerPrefs.SetInt("puzzle_1_1_h", 1);
        }
            
        if (gameMgr.puzzle1d == true)
        {
            puzzleH.SetActive(true);
            PlayerPrefs.SetInt("puzzle_1_1_h", 1);
        }
    }
}
