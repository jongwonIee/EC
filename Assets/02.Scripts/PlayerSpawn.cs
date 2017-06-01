using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {
    public GameObject player;
    public GameObject pos;
    private void Awake() {
    }
    void Start () {
        GameObject.Instantiate(player, pos.transform);
    }
	void Update () {
		
	}
}
