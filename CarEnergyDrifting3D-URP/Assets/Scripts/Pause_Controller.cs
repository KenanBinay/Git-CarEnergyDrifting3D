using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Pause_Controller : MonoBehaviour
{
    public Button resume_Button, restart_Button, mainMenu_Button;
    public GameObject resumePressed, restartPressed, mainMenuPressed, resumeUnpressed, restartUnpressed, mainMenuUnpressed;

    void Start()
    {

    }

    public void OnEnable()
    {
        restartPressed.SetActive(false);
        resumePressed.SetActive(false);
        mainMenuPressed.SetActive(false);

        restartUnpressed.SetActive(true);
        resumeUnpressed.SetActive(true);
        mainMenuUnpressed.SetActive(true);

        resume_Button.onClick.AddListener(() => resumeClick());
        restart_Button.onClick.AddListener(() => restartClick());
        mainMenu_Button.onClick.AddListener(() => mainMenuClick());
    }

    void resumeClick()
    {
        resumeUnpressed.SetActive(false);
        resumePressed.SetActive(true);

        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    void restartClick()
    {
        restartUnpressed.SetActive(false);
        restartPressed.SetActive(true);

        SceneManager.LoadScene(GlassSpawner.sceneName);
    }

    void mainMenuClick()
    {
        mainMenuUnpressed.SetActive(false);
        mainMenuPressed.SetActive(true);

        SceneManager.LoadScene("Menu");
    }

}
