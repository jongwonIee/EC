using UnityEngine;
using System.Collections;

public class Summon : MonoBehaviour {
    void Start() {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        GameObject.Find("Player/Controller/PanelScore").SetActive(true);
        Player.transform.position = GameObject.Find("SpawnPoint").transform.position;
    }
}
