using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneCtrl : MonoBehaviour {
    public GameObject player;
    public GameObject menu;
    MenuCtrl MenuController;
    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start() {
    }
    public void OnStartTouch() {
      menu.SetActive(true);
      LoadingScreenManager.LoadScene(1);
      GameObject.Find("Main Camera").SetActive(false);
    }
    void MoveStage(int stageNum) {
      LoadingScreenManager.LoadScene(stageNum + 2);
    }
}
