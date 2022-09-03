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
    public TextMeshProUGUI coinText, carPriceTxt;
    public GameObject mainMenu, shopMenu, buyButtonNormal, buyButtonPressed, settingsSprite, homeSprite, car1_go, car2_go, car3_go, car4_go;
    public static int car1_save, car2_save, car3_save, car4_save, selectedCarNumb;
    int carNumb, carPrice, priceD, coinX;
    void Start()
    {
        carNumb = 1;
        car1_save = 1;
        car2_save = PlayerPrefs.GetInt("car2_saved", 0);
        car3_save = PlayerPrefs.GetInt("car3_saved", 0);
        car4_save = PlayerPrefs.GetInt("car4_saved", 0);
        Debug.Log("car1Save: " + car1_save + " || car2Save: " + car2_save + " || car3Save: " + car3_save + " || car4Save: " + car4_save + " || Coin: " + LevelController.coinSaved);

        carPriceTxt.text = 0.ToString();     
        shopMenu.SetActive(false);
        mainMenu.SetActive(true);
        settingsSprite.SetActive(true);
        homeSprite.SetActive(false);
        homeMenuUI.enabled = true;
        shopMenuUI.enabled = false;
    }

    void Update()
    {
        if (priceD != carPrice)
        {
            if (priceD > carPrice) { priceD -= 100; }
            if (priceD < carPrice) { priceD += 100; }
            carPriceTxt.text = priceD.ToString();
        }
        if (coinX != LevelController.coinSaved)
        {
            if (coinX > LevelController.coinSaved) { coinX -= 100; }
            if (coinX < LevelController.coinSaved) { coinX += 100; }
            coinText.text = coinX.ToString();
        }
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

        shopMenuUI.SetTrigger("carShowing");
        shopMenuUI.enabled = true;
        homeMenuUI.enabled = false;
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

    void nextCarButtonL()
    {
        if (carNumb != 1) { carNumb--; }

        if (carNumb == 1)
        {
            carPrice = 0000;
            car1_go.SetActive(true);
            car2_go.SetActive(false);
        }
        if (carNumb == 2)
        {
            carPrice = 270;
            car2_go.SetActive(true);
            car3_go.SetActive(false);
        }
        if (carNumb == 3)
        {
            carPrice = 740;
            car3_go.SetActive(true);
            car4_go.SetActive(false);
        }

        Debug.Log("Car Number: " + carNumb + " || CarPriceSet: " + carPrice);
        shopMenuUI.SetTrigger("carShowing");
    }

    void nextCarButtonR()
    {
        if (carNumb != 4) { carNumb++; }

        if (carNumb == 2)
        {
            carPrice = 270;
            car2_go.SetActive(true);
            car1_go.SetActive(false);
        }
        if (carNumb == 3)
        {
            carPrice = 740;
            car3_go.SetActive(true);
            car2_go.SetActive(false);
        }
        if (carNumb == 4)
        {
            carPrice = 4600;
            car4_go.SetActive(true);
            car3_go.SetActive(false);
        }

        Debug.Log("Car Number: " + carNumb + " || CarPriceSet: " + carPrice);
        shopMenuUI.SetTrigger("carShowing");
    }

    void buyButtonOnPress()
    {
        buyButtonNormal.SetActive(false);
        buyButtonPressed.SetActive(true);

        if (carNumb == 2 || car2_save != 1)
        {
            if (LevelController.coinSaved >= 270)
            {
                PlayerPrefs.SetInt("car2_saved", 1);
                LevelController.coinSaved -= 270;

                shopMenuUI.SetTrigger("carBuyed");
                Debug.Log("Buyed || car number: " + carNumb + " || Coin: " + PlayerPrefs.GetInt("coin", 0));
            }
        }
        if (carNumb == 3 || car4_save != 1)
        {
            if (LevelController.coinSaved >= 740)
            {
                PlayerPrefs.SetInt("car3_saved", 1);
                LevelController.coinSaved -= 740;

                shopMenuUI.SetTrigger("carBuyed");
                Debug.Log("Buyed || car number: " + carNumb + " || Coin: " + PlayerPrefs.GetInt("coin", 0));
            }
        }
        if (carNumb == 4 || car4_save != 1)
        {
            if (LevelController.coinSaved >= 4600)
            {
                PlayerPrefs.SetInt("car4_saved", 1);
                LevelController.coinSaved -= 4600;
                shopMenuUI.SetTrigger("carBuyed");

                Debug.Log("Buyed || car number: " + carNumb + " || Coin: " + PlayerPrefs.GetInt("coin", 0));
            }
        }
     
        StartCoroutine(buyButtonDelay());
    }

    IEnumerator buyButtonDelay()
    {
        yield return new WaitForSeconds(0.5f);
        buyButtonPressed.SetActive(false);
        buyButtonNormal.SetActive(true);
    }
}
