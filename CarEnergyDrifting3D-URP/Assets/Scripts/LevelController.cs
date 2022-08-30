using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelController : MonoBehaviour
{
    public static int currentLevel = 1, levelSave, coinSaved;
    public Button button_MenuButton;
    public GameObject pauseUI, gameOverUI;
    public TMPro.TextMeshProUGUI coinTxt_PauseUI;

    void Start()
    {
        //   currentLevel = PlayerPrefs.GetFloat("level_main", 0);
       
        pauseUI.SetActive(false);
        gameOverUI.SetActive(false);
        coinSaved = PlayerPrefs.GetInt("coin", 0);
        Debug.Log("CurrentCoin: " + PlayerPrefs.GetInt("coin", 0));
        Debug.Log("CurrentLevel: " + PlayerPrefs.GetInt("level_main"));
        Debug.Log("SelectedCar: " + PlayerPrefs.GetInt("selectedCar"));

    }
    void Update()
    {
        if (Pause_Controller.paused == false)
        {
            if (Time.timeScale != 1f) { Time.timeScale = 1f; }
        }

        if (CarController._frontCollision)
        {
            gameOver();
        }
    }

    private void OnEnable()
    {
        if (Pause_Controller.paused == false || CarController._frontCollision || CarController.gameEnd) { button_MenuButton.onClick.AddListener(() => StartCoroutine(menuDelay())); }
    }

    void menuClick()
    {
        Pause_Controller.paused = true;       
        coinTxt_PauseUI.text = coinSaved.ToString();
        Time.timeScale = 0f;
    }

    void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    IEnumerator menuDelay()
    {
        pauseUI.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        menuClick();
    }
}
