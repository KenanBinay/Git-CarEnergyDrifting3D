using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu_Controller : MonoBehaviour
{
    public Button button_TapToPLay, button_shop, button_settings, button_home, button_buy, button_R, button_L;
    public Animator shopIcon,homeMenuUI,shopMenuUI;
    public TextMeshProUGUI coinText;
    public GameObject mainMenu, shopMenu, buyButtonNormal, buyButtonPressed, settingsSprite, homeSprite;
    public static int car1, car2, car3, car4, selectedCarNumb;
    int carNumb;
    void Start()
    {
        car1 = 1; car2 = 2; car3 = 3; car4 = 4;   
        coinText.text = LevelController.coinSaved.ToString();
        shopMenu.SetActive(false);
        mainMenu.SetActive(true);
        settingsSprite.SetActive(true);
        homeSprite.SetActive(false);
        homeMenuUI.enabled = true;
        shopMenuUI.enabled = false;
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
        button_R.onClick.AddListener(() => nextCarButtonR());
        button_L.onClick.AddListener(() => nextCarButtonL());
    }

    void shopLoad()
    {
        
        settingsSprite.SetActive(false);
        homeSprite.SetActive(true);
        mainMenu.SetActive(false);
        shopMenu.SetActive(true);

        shopMenuUI.enabled = true;
        homeMenuUI.enabled = false;
        shopMenuUI.SetTrigger("carShowing");
    }

    void homeLoad()
    {
        homeMenuUI.enabled = true;
        shopMenuUI.enabled = false;
        shopMenuUI.SetTrigger("carShowing");
        settingsSprite.SetActive(true);
        homeSprite.SetActive(false);
        mainMenu.SetActive(true);
        shopMenu.SetActive(false);
    }

    void settingsLoad()
    {

    }


    void nextCarButtonR()
    {
        carNumb++;
    }

    void nextCarButtonL()
    {
        carNumb--;
    }

    void buyButtonOnPress()
    {
        buyButtonNormal.SetActive(false);
        buyButtonPressed.SetActive(true);

        if (carNumb == 1)
        {

        }
        if (carNumb == 2)
        {

        }

        Debug.Log("Car buyed, car number: " + carNumb);

        StartCoroutine(buyButtonDelay());
    }

    IEnumerator buyButtonDelay()
    {
        yield return new WaitForSeconds(0.5f);
        buyButtonPressed.SetActive(false);
        buyButtonNormal.SetActive(true);
    }
}
