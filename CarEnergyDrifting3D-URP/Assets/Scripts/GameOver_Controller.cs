using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver_Controller : MonoBehaviour
{
    public Button restart_Button, mainMenu_Button;
    public GameObject restartPressed, mainMenuPressed, restartUnpressed, mainMenuUnpressed;
    public static bool gameOver;

    void Start()
    {
        
    }

    public void OnEnable()
    {
        restartPressed.SetActive(false);
        mainMenuPressed.SetActive(false);

        restartUnpressed.SetActive(true);
        mainMenuUnpressed.SetActive(true);

        restart_Button.onClick.AddListener(() => restartClick());
        mainMenu_Button.onClick.AddListener(() => mainMenuClick());
    }

    void restartClick()
    {
        restartUnpressed.SetActive(false);
        restartPressed.SetActive(true);

        gameOver = false;
        CarController.gameEnd = false;
        SceneManager.LoadScene(GlassSpawner.sceneName);
    }

    void mainMenuClick()
    {
        mainMenuUnpressed.SetActive(false);
        mainMenuPressed.SetActive(true);

        gameOver = false;
        SceneManager.LoadScene("Menu");
    }
}
