using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class MenuCtrl : MonoBehaviour {
    public GameObject Menu;
    public GameObject[] list;
    public GameObject player;
    public Transform[] listChild;
    public bool OnMenu = false;
    int i;
    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start() {
        //listChild = Menu.GetComponentsInChildren<Transform>(true);
        list = new GameObject[50];
            list[0] = GameObject.Find("/Player/Menu/Menu_Panel");
            list[1] = GameObject.Find("/Player/Menu/Resume");
            list[2] = GameObject.Find("/Player/Menu/Pause");
            list[3] = GameObject.Find("/Player/Menu/Menu_Panel/ListOptions/Button_Options/Options");
    }

    public void button_pause() {
        Time.timeScale = 0;
        list[0].SetActive(true);
        list[1].SetActive(true);
        list[2].SetActive(false);
        list[3].SetActive(false);
    }

    public void button_resume() {
        Time.timeScale = 1;
        list[0].SetActive(false);
        list[1].SetActive(false);
        list[2].SetActive(true);
        list[3].SetActive(false);
    }

    public void button_MainMenu() {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        if (SceneManager.GetActiveScene().buildIndex != 1) {
            LoadingScreenManager.LoadScene(1);
            Time.timeScale = 1;
            list[0].SetActive(false);
            list[1].SetActive(false);
            list[2].SetActive(true);
            list[3].SetActive(false);
        } else {
            button_resume();
            Debug.Log("asdfasd");
        }
    }

    public void button_Options() {
        list[3].SetActive(true);
    }

    public void button_ExitGame() {
        Debug.Log("exit");
        Application.Quit();
    }

    //public void exitPause() {
    //    Time.timeScale = 1;

    //    //if(canvas[])
    //    //if Main Menu is on, turn off.

    //}

    /* public Rect windowRect = new Rect(20, 20, 120, 50);
     void OnGUI() {
         windowRect = GUI.Window(0, windowRect, DoMyWindow, "My Window");
     }
     void DoMyWindow(int windowID) {
         if (GUI.Button(new Rect(10, 20, 100, 20), "Hello World"))
             print("Got a click");
     }*/
}
