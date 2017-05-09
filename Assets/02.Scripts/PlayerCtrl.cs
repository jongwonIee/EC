using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCtrl : MonoBehaviour {
    public void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
}
