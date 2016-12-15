using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerCasting : MonoBehaviour {
    
    public float Range = 5.0f;
    public float TargetDistance;
    public Transform firePos;
    public GameObject musicObject;
    public GameObject lightObject;

    void Update () {
        RaycastHit hit;
        if (CnControls.CnInputManager.GetButtonDown("Action"))
        {

            if (Physics.Raycast (firePos.position, firePos.TransformDirection(Vector3.forward), out hit))
            {
                TargetDistance = hit.distance;
                if (TargetDistance < Range && hit.collider.tag == "OBJECT")
                {
                    Action();
                    hit.collider.tag = "Untagged";
                }
            }
        }
    }

    void Action()
    {
        Debug.Log("actionactivated");
        musicObject.SetActive(true);
        lightObject.SetActive(false);
    }
}
