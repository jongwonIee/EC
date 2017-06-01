using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StageCtrl : MonoBehaviour {
    public int stageNum;
    private Transform a;
    
    void Awake() {
    }
    
    void OnTriggerEnter(Collider coll) {
        if (coll.tag == "Player") {
            LoadingScreenManager.LoadScene(stageNum + 1);
        }
    }
}
