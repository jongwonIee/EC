using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneCtrl : MonoBehaviour {
    public GameObject player;
    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start() {

    }
    public void OnStartTouch() {
      LoadingScreenManager.LoadScene(1);
      GameObject.Find("Main Camera").SetActive(false);
    }
    void MoveStage(int stageNum) {
      LoadingScreenManager.LoadScene(stageNum + 2);
    }
}
