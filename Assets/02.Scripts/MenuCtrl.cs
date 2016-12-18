using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCtrl : MonoBehaviour {
    public GameObject[] canvas;
    public void pause() {
        canvas[0].SetActive(true);
        canvas[1].SetActive(false);
        canvas[2].SetActive(true);
        canvas[3].SetActive(false);
        Time.timeScale = 0;

    }
    public void exitPause() {
        canvas[0].SetActive(false);
        canvas[1].SetActive(true);
        canvas[2].SetActive(false);
        canvas[3].SetActive(true);
        Time.timeScale = 1;
    }

    public void buttonMainMenu() {

    }

    public void buttonExitGame() {
        Application.Quit();
    }

   /* public Rect windowRect = new Rect(20, 20, 120, 50);
    void OnGUI() {
        windowRect = GUI.Window(0, windowRect, DoMyWindow, "My Window");
    }
    void DoMyWindow(int windowID) {
        if (GUI.Button(new Rect(10, 20, 100, 20), "Hello World"))
            print("Got a click");
    }*/
}
