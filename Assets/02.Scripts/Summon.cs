using UnityEngine;
using System.Collections;

public class Summon : MonoBehaviour {
    private Transform tr;
    void Start() {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        GameObject Child = GameObject.Find("Player/RigidBodyFPSController");
        GameObject.Find("Player/Controller/PanelScore").SetActive(true);

        tr = GameObject.Find("SpawnPoint").transform;

        Player.transform.position = tr.position;
        Player.transform.rotation = tr.rotation;
        Child.transform.position = tr.position;
        Child.transform.rotation = tr.rotation;
    }
}
