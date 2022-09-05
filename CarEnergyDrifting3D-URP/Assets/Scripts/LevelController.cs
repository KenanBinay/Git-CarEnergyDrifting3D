using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelController : MonoBehaviour
{
    public static int currentLevel = 1, levelSave, coinSaved;
    public Button button_MenuButton;
    public GameObject pauseUI, gameOverUI, car1, car2, car3, car4;
    public TMPro.TextMeshProUGUI coinTxt_PauseUI;

    void Start()
    {
        //   currentLevel = PlayerPrefs.GetFloat("level_main", 0);
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
        gameOverUI.SetActive(false);
        coinSaved = PlayerPrefs.GetInt("coin", 0);
        Debug.Log("CurrentCoin: " + PlayerPrefs.GetInt("coin", 0));
        Debug.Log("CurrentLevel: " + PlayerPrefs.GetInt("level_main"));
        Debug.Log("SelectedCar: " + PlayerPrefs.GetInt("selectedCar"));

        car1.SetActive(false); car2.SetActive(false); car3.SetActive(false); car4.SetActive(false);

        if (Menu_Controller.selectedCarNumb == 1) { car1.SetActive(true); }
        if (Menu_Controller.selectedCarNumb == 2) { car2.SetActive(true); }
        if (Menu_Controller.selectedCarNumb == 3) { car3.SetActive(true); }
        if (Menu_Controller.selectedCarNumb == 4) { car4.SetActive(true); }
    }
    void Update()
    {        
    //    if (coinSaved != PlayerPrefs.GetInt("coin", 0)) { PlayerPrefs.SetInt("coin", coinSaved); }

        if (Pause_Controller.paused == false)
        {
            if (Time.timeScale != 1f) { Time.timeScale = 1f; }
        }

        if (CarController._frontCollision) { gameOver(); }
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
