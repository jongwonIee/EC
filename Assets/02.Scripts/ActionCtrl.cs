using UnityEngine;
using System.Collections;

public class ActionCtrl : MonoBehaviour {
    bool currState = false;
    public AnimationClip doorClip;
    public Animation[] doorAnim;
    private int i = 0;
    void Start () {
       
	}
	
	void Update () {
	
	}

    void Action() {
        if (!currState) { 
            GetComponent<Animation>().Play("Door_Large_Open");
        }
        else if (currState) {
            GetComponent<Animation>().Play("Door_Large_Close");
        }
    }
}
