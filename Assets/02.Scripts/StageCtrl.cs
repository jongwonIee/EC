using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StageCtrl : MonoBehaviour {
    public int stageNum;
    private Transform a;
    
	void Start () {
	
	}

    void Awake() {
        DontDestroyOnLoad(GameObject.Find("Playerr"));
        DontDestroyOnLoad(GameObject.Find("Controller"));
        DontDestroyOnLoad(GameObject.Find("EventSystem"));
    }

    void Update () {
    }

    void OnTriggerEnter(Collider coll) {
        if (coll.tag == "Player") {
            SceneManager.LoadScene(stageNum + 2);
        }
    }
}
