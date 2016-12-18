using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneCtrl : MonoBehaviour {
    void Start() {

    }
    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
    public void OnStartTouch() {
        SceneManager.LoadScene("Menu");
    }
    void MoveStage(int stageNum) {
        SceneManager.LoadScene(stageNum + 2);
    }

}