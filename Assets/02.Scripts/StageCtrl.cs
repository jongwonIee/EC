using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StageCtrl : MonoBehaviour {
    public int stageNum;
    private GameMgr gameMgr;
    private Transform a;

    private void Start() {
//        gameMgr = GameObject.Find("GameManager").GetComponent<GameMgr>();
    }
    
    void Awake() {
    }
    
    void OnTriggerEnter(Collider coll) {
        if (coll.tag == "Player") {
            LoadingScreenManager.LoadScene(stageNum + 1);
        }
    }
}
