using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneCtrl : MonoBehaviour {
    void Start() {
        SceneManager.LoadScene("Menu");

    }
    public void OnTouch() {
        //SceneManager.UnloadScene("_Start");
    }
}