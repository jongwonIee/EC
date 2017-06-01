using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {
    public GameObject player;
    public GameObject pos;
    private void Awake() {
        player = GameObject.Instantiate(player, pos.transform.position, new Quaternion(0,0,0,0));
        player.name = "Player";
    }
    void Start () {
    }
	void Update () {
		
	}
}
