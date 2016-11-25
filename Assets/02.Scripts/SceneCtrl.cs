using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneCtrl : MonoBehaviour {

	void Start () {
	}

    void update() {
            Debug.Log("d");
        
            SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }
	
}