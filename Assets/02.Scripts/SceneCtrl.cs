using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneCtrl : MonoBehaviour {
    MenuCtrl MenuController;
    void Awake() {
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
