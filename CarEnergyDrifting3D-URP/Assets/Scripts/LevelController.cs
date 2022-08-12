using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelController : MonoBehaviour
{
    public static int currentLevel = 1, levelSave, coinSaved;
    public Button button_MenuButton;
    public GameObject pauseUI;

    void Start()
    {
        //   currentLevel = PlayerPrefs.GetFloat("level_main", 0);
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
        coinSaved = PlayerPrefs.GetInt("coin", 0);
        Debug.Log("CurrentCoin: " + PlayerPrefs.GetInt("coin", 0));
        Debug.Log("CurrentLevel: " + PlayerPrefs.GetInt("level_main"));

    }
    void Update()
    {

    }

    private void OnEnable()
    {
        button_MenuButton.onClick.AddListener(() => menuClick());
    }

    void menuClick()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
    }

}
