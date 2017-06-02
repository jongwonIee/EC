using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCtrl : MonoBehaviour {
    public static MenuCtrl MenuController;
    public GameObject Menu;
    public GameObject[] list;
    public Text[] textList;
    public Transform[] listChild;
    public bool OnMenu = false;
    int i;
    private bool statOn = false;
    private void Awake() {
        MenuController = this;
    }

    void Start() {
    }
    public void button_statistics() {
        list[5].SetActive(true);
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
    
    public void button_BOX1() {
        textList[0].gameObject.SetActive(false);
        textList[1].gameObject.SetActive(false);
        textList[2].gameObject.SetActive(false);
        textList[3].gameObject.SetActive(false);
        textList[4].gameObject.SetActive(true);
        textList[4].text = "LEVEL1-1:" + PlayerPrefs.GetInt("HIGH_SCORE_1_1");
        textList[5].gameObject.SetActive(true);
        textList[5].text = "LEVEL1-2:" + PlayerPrefs.GetInt("HIGH_SCORE_1_2");
        textList[6].gameObject.SetActive(true);
        textList[6].text = "LEVEL1-3:" + PlayerPrefs.GetInt("HIGH_SCORE_1_3");
        textList[7].gameObject.SetActive(true);
        textList[7].text = "LEVEL1-4:" + PlayerPrefs.GetInt("HIGH_SCORE_1_4");
        //textList[8].text = "PART1:" + PlayerPrefs.GetInt("");
        if (PlayerPrefs.GetInt("puzzle_1_1_a") == 1) { textList[8].gameObject.SetActive(true); textList[8].text = "PART1"; } else { textList[8].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_1_1_b") == 1) { textList[9].gameObject.SetActive(true); textList[9].text = "PART2"; } else { textList[9].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_1_1_c") == 1) { textList[10].gameObject.SetActive(true); textList[10].text = "PART3"; } else { textList[10].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_1_1_d") == 1) { textList[11].gameObject.SetActive(true); textList[11].text = "PART4"; } else { textList[11].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_1_2_a") == 1) { textList[12].gameObject.SetActive(true); textList[12].text = "PART1"; } else { textList[12].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_1_2_b") == 1) { textList[13].gameObject.SetActive(true); textList[13].text = "PART2"; } else { textList[13].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_1_2_c") == 1) { textList[14].gameObject.SetActive(true); textList[14].text = "PART3"; } else { textList[14].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_1_2_d") == 1) { textList[15].gameObject.SetActive(true); textList[15].text = "PART4"; } else { textList[15].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_1_3_a") == 1) { textList[16].gameObject.SetActive(true); textList[16].text = "PART1"; } else { textList[16].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_1_3_b") == 1) { textList[17].gameObject.SetActive(true); textList[17].text = "PART2"; } else { textList[17].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_1_3_c") == 1) { textList[18].gameObject.SetActive(true); textList[18].text = "PART3"; } else { textList[18].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_1_3_d") == 1) { textList[19].gameObject.SetActive(true); textList[19].text = "PART4"; } else { textList[19].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_1_4_a") == 1) { textList[20].gameObject.SetActive(true); textList[20].text = "PART1"; } else { textList[20].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_1_4_b") == 1) { textList[21].gameObject.SetActive(true); textList[21].text = "PART2"; } else { textList[21].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_1_4_c") == 1) { textList[22].gameObject.SetActive(true); textList[22].text = "PART3"; } else { textList[22].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_1_4_d") == 1) { textList[23].gameObject.SetActive(true); textList[23].text = "PART4"; } else { textList[23].gameObject.SetActive(false); }
        textList[24].text = "STAGE1";
        statOn = true;
    }
    public void button_BOX2() {
        textList[0].gameObject.SetActive(false);
        textList[1].gameObject.SetActive(false);
        textList[2].gameObject.SetActive(false);
        textList[3].gameObject.SetActive(false);
        textList[4].gameObject.SetActive(true);
        textList[4].text = "LEVEL 2-1:" + PlayerPrefs.GetInt("HIGH_SCORE_2_1");
        textList[5].gameObject.SetActive(true);
        textList[5].text = "LEVEL 2-2:" + PlayerPrefs.GetInt("HIGH_SCORE_2_2");
        textList[6].gameObject.SetActive(true);
        textList[6].text = "LEVEL 2-3:" + PlayerPrefs.GetInt("HIGH_SCORE_2_3");
        textList[7].gameObject.SetActive(true);
        textList[7].text = "LEVEL 2-4:" + PlayerPrefs.GetInt("HIGH_SCORE_2_4");
        if (PlayerPrefs.GetInt("puzzle_2_1_a") == 1) { textList[8].gameObject.SetActive(true); textList[8].text = "PART1"; } else { textList[8].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_2_1_b") == 1) { textList[9].gameObject.SetActive(true); textList[9].text = "PART2"; } else { textList[9].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_2_1_c") == 1) { textList[10].gameObject.SetActive(true); textList[10].text = "PART3"; } else { textList[10].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_2_1_d") == 1) { textList[11].gameObject.SetActive(true); textList[11].text = "PART4"; } else { textList[11].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_2_2_a") == 1) { textList[12].gameObject.SetActive(true); textList[12].text = "PART1"; } else { textList[12].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_2_2_b") == 1) { textList[13].gameObject.SetActive(true); textList[13].text = "PART2"; } else { textList[13].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_2_2_c") == 1) { textList[14].gameObject.SetActive(true); textList[14].text = "PART3"; } else { textList[14].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_2_2_d") == 1) { textList[15].gameObject.SetActive(true); textList[15].text = "PART4"; } else { textList[15].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_2_3_a") == 1) { textList[16].gameObject.SetActive(true); textList[16].text = "PART1"; } else { textList[16].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_2_3_b") == 1) { textList[17].gameObject.SetActive(true); textList[17].text = "PART2"; } else { textList[17].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_2_3_c") == 1) { textList[18].gameObject.SetActive(true); textList[18].text = "PART3"; } else { textList[18].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_2_3_d") == 1) { textList[19].gameObject.SetActive(true); textList[19].text = "PART4"; } else { textList[19].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_2_4_a") == 1) { textList[20].gameObject.SetActive(true); textList[20].text = "PART1"; } else { textList[20].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_2_4_b") == 1) { textList[21].gameObject.SetActive(true); textList[21].text = "PART2"; } else { textList[21].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_2_4_c") == 1) { textList[22].gameObject.SetActive(true); textList[22].text = "PART3"; } else { textList[22].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_2_4_d") == 1) { textList[23].gameObject.SetActive(true); textList[23].text = "PART4"; } else { textList[23].gameObject.SetActive(false); }
        textList[24].text = "STAGE2";
        statOn = true;
    }
    public void button_BOX3() {
        textList[0].gameObject.SetActive(false);
        textList[1].gameObject.SetActive(false);
        textList[2].gameObject.SetActive(false);
        textList[3].gameObject.SetActive(false);
        textList[4].gameObject.SetActive(true);
        textList[4].text = "LEVEL 3-1:" + PlayerPrefs.GetInt("HIGH_SCORE_3_1");
        textList[5].gameObject.SetActive(true);
        textList[5].text = "LEVEL 3-2:" + PlayerPrefs.GetInt("HIGH_SCORE_3_2");
        textList[6].gameObject.SetActive(true);
        textList[6].text = "LEVEL 3-3:" + PlayerPrefs.GetInt("HIGH_SCORE_3_3");
        textList[7].gameObject.SetActive(true);
        textList[7].text = "LEVEL 3-4:" + PlayerPrefs.GetInt("HIGH_SCORE_3_4");
        if (PlayerPrefs.GetInt("puzzle_3_1_a") == 1) { textList[8].gameObject.SetActive(true); textList[8].text = "PART1"; } else { textList[8].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_3_1_b") == 1) { textList[9].gameObject.SetActive(true); textList[9].text = "PART2"; } else { textList[9].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_3_1_c") == 1) { textList[10].gameObject.SetActive(true); textList[10].text = "PART3"; } else { textList[10].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_3_1_d") == 1) { textList[11].gameObject.SetActive(true); textList[11].text = "PART4"; } else { textList[11].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_3_2_a") == 1) { textList[12].gameObject.SetActive(true); textList[12].text = "PART1"; } else { textList[12].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_3_2_b") == 1) { textList[13].gameObject.SetActive(true); textList[13].text = "PART2"; } else { textList[13].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_3_2_c") == 1) { textList[14].gameObject.SetActive(true); textList[14].text = "PART3"; } else { textList[14].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_3_2_d") == 1) { textList[15].gameObject.SetActive(true); textList[15].text = "PART4"; } else { textList[15].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_3_3_a") == 1) { textList[16].gameObject.SetActive(true); textList[16].text = "PART1"; } else { textList[16].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_3_3_b") == 1) { textList[17].gameObject.SetActive(true); textList[17].text = "PART2"; } else { textList[17].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_3_3_c") == 1) { textList[18].gameObject.SetActive(true); textList[18].text = "PART3"; } else { textList[18].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_3_3_d") == 1) { textList[19].gameObject.SetActive(true); textList[19].text = "PART4"; } else { textList[19].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_3_4_a") == 1) { textList[20].gameObject.SetActive(true); textList[20].text = "PART1"; } else { textList[20].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_3_4_b") == 1) { textList[21].gameObject.SetActive(true); textList[21].text = "PART2"; } else { textList[21].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_3_4_c") == 1) { textList[22].gameObject.SetActive(true); textList[22].text = "PART3"; } else { textList[22].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_3_4_d") == 1) { textList[23].gameObject.SetActive(true); textList[23].text = "PART4"; } else { textList[23].gameObject.SetActive(false); }
        textList[24].text = "STAGE3";
        statOn = true;
    }
    public void button_BOX4() {
        textList[0].gameObject.SetActive(false);
        textList[1].gameObject.SetActive(false);
        textList[2].gameObject.SetActive(false);
        textList[3].gameObject.SetActive(false);
        textList[4].gameObject.SetActive(true);
        textList[4].text = "LEVEL 4-1:" + PlayerPrefs.GetInt("HIGH_SCORE_4_1");
        textList[5].gameObject.SetActive(true);
        textList[5].text = "LEVEL 4-2:" + PlayerPrefs.GetInt("HIGH_SCORE_4_2");
        textList[6].gameObject.SetActive(true);
        textList[6].text = "LEVEL 4-3:" + PlayerPrefs.GetInt("HIGH_SCORE_4_3");
        textList[7].gameObject.SetActive(true);
        textList[7].text = "LEVEL 4-4:" + PlayerPrefs.GetInt("HIGH_SCORE_4_4");
        if (PlayerPrefs.GetInt("puzzle_4_1_a") == 1) { textList[8].gameObject.SetActive(true); textList[8].text = "PART1"; } else { textList[8].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_4_1_b") == 1) { textList[9].gameObject.SetActive(true); textList[9].text = "PART2"; } else { textList[9].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_4_1_c") == 1) { textList[10].gameObject.SetActive(true); textList[10].text = "PART3"; } else { textList[10].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_4_1_d") == 1) { textList[11].gameObject.SetActive(true); textList[11].text = "PART4"; } else { textList[11].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_4_2_a") == 1) { textList[12].gameObject.SetActive(true); textList[12].text = "PART1"; } else { textList[12].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_4_2_b") == 1) { textList[13].gameObject.SetActive(true); textList[13].text = "PART2"; } else { textList[13].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_4_2_c") == 1) { textList[14].gameObject.SetActive(true); textList[14].text = "PART3"; } else { textList[14].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_4_2_d") == 1) { textList[15].gameObject.SetActive(true); textList[15].text = "PART4"; } else { textList[15].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_4_3_a") == 1) { textList[16].gameObject.SetActive(true); textList[12].text = "PART1"; } else { textList[16].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_4_3_b") == 1) { textList[17].gameObject.SetActive(true); textList[13].text = "PART2"; } else { textList[17].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_4_3_c") == 1) { textList[18].gameObject.SetActive(true); textList[14].text = "PART3"; } else { textList[18].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_4_3_d") == 1) { textList[19].gameObject.SetActive(true); textList[15].text = "PART4"; } else { textList[19].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_4_4_a") == 1) { textList[20].gameObject.SetActive(true); textList[12].text = "PART1"; } else { textList[20].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_4_4_b") == 1) { textList[21].gameObject.SetActive(true); textList[13].text = "PART2"; } else { textList[21].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_4_4_c") == 1) { textList[22].gameObject.SetActive(true); textList[14].text = "PART3"; } else { textList[22].gameObject.SetActive(false); }
        if (PlayerPrefs.GetInt("puzzle_4_4_d") == 1) { textList[23].gameObject.SetActive(true); textList[15].text = "PART4"; } else { textList[23].gameObject.SetActive(false); }
        textList[24].text = "STAGE4";
        statOn = true;
    }
    public void backtogame() {
        if (statOn) {
            textList[0].gameObject.SetActive(true);
            textList[1].gameObject.SetActive(true);
            textList[2].gameObject.SetActive(true);
            textList[3].gameObject.SetActive(true);
        for(int i = 4; i < 24; i++) {
            textList[i].gameObject.SetActive(false);
        }
            textList[24].text = "exit";
            statOn = false;
        }
        else {
            list[5].SetActive(false);
        }
    }
}
