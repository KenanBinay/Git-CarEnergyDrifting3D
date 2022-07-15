using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu_Controller : MonoBehaviour
{
    public Button button_TapToPLay, button_shop, button_settings;
    public Animator shopIcon;
    public TextMeshProUGUI coinText;
    public GameObject mainMenu, shopMenu;

    void Start()
    {
        coinText.text = LevelController.coinSaved.ToString();
        shopMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    void Update()
    {

    }

    void OnEnable()
    {
        //Register Button Events
        button_TapToPLay.onClick.AddListener(() => SceneManager.LoadScene(LevelController.currentLevel));
        button_shop.onClick.AddListener(() => shopLoad());
        button_settings.onClick.AddListener(() => settingsLoad());
    }

    void shopLoad()
    {
        mainMenu.SetActive(false);
        shopMenu.SetActive(true);
    }

    void settingsLoad()
    {

    }
}
