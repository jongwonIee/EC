using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {
    private void Awake() {
    }
    void Start () {
        GameObject player = GameObject.Find("Player");
        player.SetActive(true);
        player.transform.position = new Vector3(0, 0, 0);
    }
	
	void Update () {
		
	}
}
