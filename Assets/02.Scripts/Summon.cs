using UnityEngine;
using System.Collections;

public class Summon : MonoBehaviour {
    void Awake() {
        GameObject.Find("Playerr").transform.position = GameObject.Find("SpawnPoint").transform.position;
    }
	void Start () {
	
	}
	
	void Update () {
	
	}
}
