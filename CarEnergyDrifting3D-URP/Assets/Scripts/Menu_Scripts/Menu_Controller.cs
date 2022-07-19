using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu_Controller : MonoBehaviour
{
    public Button button_TapToPLay, button_shop, button_settings, button_home, button_buy, button_R, button_L;
    public Animator shopIcon;
    public TextMeshProUGUI coinText;
    public GameObject mainMenu, shopMenu, buyButtonNormal, buyButtonPressed;
    int carNumb;

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
        button_home.onClick.AddListener(() => homeLoad());
        button_buy.onClick.AddListener(() => buyButtonOnPress());
        button_R.onClick.AddListener(() => carNumb++);
        button_R.onClick.AddListener(() => carNumb--);
    }

    void shopLoad()
    {
        mainMenu.SetActive(false);
        shopMenu.SetActive(true);
    }

    void homeLoad()
    {
        mainMenu.SetActive(true);
        shopMenu.SetActive(false);
    }

    void settingsLoad()
    {

    }

    void buyButtonOnPress()
    {
        buyButtonNormal.SetActive(false);
        buyButtonPressed.SetActive(true);
        StartCoroutine(buyButtonDelay());
    }

    IEnumerator buyButtonDelay()
    {
        yield return new WaitForSeconds(0.5f);
        buyButtonPressed.SetActive(false);
        buyButtonNormal.SetActive(true);
    }
}
