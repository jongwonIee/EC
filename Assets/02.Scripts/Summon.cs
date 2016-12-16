using UnityEngine;
using System.Collections;

public class Summon : MonoBehaviour {
    public GameObject respawnPrefab;
    public GameObject respawn;
    void Start() {
        if (respawn == null)
            respawn = GameObject.FindGameObjectWithTag("Respawn");
        Instantiate(respawnPrefab, respawn.transform.position, respawn.transform.rotation);
    }
}
