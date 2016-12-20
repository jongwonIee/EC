using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMusicObject : MonoBehaviour {
    private GameObject music1;

    void Start() {
        music1 = GameObject.Find("Player/Controller/Music1");
    }
    void OnTriggerEnter(Collider coll) {
        music1.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
