using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu_Controller : MonoBehaviour
{
    public Button button_TapToPLay, button_shop, button_settings, button_home, button_buy, button_R, button_L;
    public Animator shopIcon, homeMenuUI, shopMenuUI;
    public TextMeshProUGUI coinText, carPriceTxt;
    public GameObject mainMenu, shopMenu, buyButtonNormal, buyButtonPressed, settingsSprite, homeSprite, carSelectedSprite, car1_go, car2_go, car3_go, car4_go,car1_Menu, car2_Menu, car3_Menu, car4_Menu;
    public static int car1_save, car2_save, car3_save, car4_save;
    int carNumb, carPrice, carSelectionNumb, priceD, coinX, menuCoinVal;

    public static bool sfxOn;
    void Start()
    {
        sfxOn = true;
        priceD = coinX = 0;
        carNumb = 1;
        car1_save = 1;
        car2_save = PlayerPrefs.GetInt("car2_saved", 0);
        car3_save = PlayerPrefs.GetInt("car3_saved", 0);
        car4_save = PlayerPrefs.GetInt("car4_saved", 0);
        menuCoinVal = PlayerPrefs.GetInt("coin", 0);

        carPriceTxt.text = 0.ToString();
        shopMenu.SetActive(false);
        homeSprite.SetActive(false);
        car1_Menu.SetActive(false);
        car2_Menu.SetActive(false);
        car3_Menu.SetActive(false);
        car4_Menu.SetActive(false);
        mainMenu.SetActive(true);
        settingsSprite.SetActive(true);
        homeMenuUI.enabled = true;
        shopMenuUI.enabled = false;

        if (PlayerPrefs.GetInt("selectedCar", 0) == 0) { carSelectionNumb = 1; }
        else { carSelectionNumb = PlayerPrefs.GetInt("selectedCar", 0); }

        Debug.Log("car1Save: " + car1_save + " || car2Save: " + car2_save + " || car3Save: " + car3_save + " || car4Save: " + car4_save);
        Debug.Log("SelectedCar: " + PlayerPrefs.GetInt("selectedCar") + " || Coin: " + PlayerPrefs.GetInt("coin", 0));
        
    }

    void Update()
    {
        if (priceD != carPrice)
        {
            if (priceD > carPrice) { priceD -= 100; }
            if (priceD < carPrice) { priceD += 100; }
            carPriceTxt.text = priceD.ToString();
        }
        if (coinX != menuCoinVal)
        {
            if (coinX > menuCoinVal) { coinX -= 1; }
            if (coinX < menuCoinVal) { coinX += 1; }
            coinText.text = coinX.ToString();
        }

        if (carNumb != carSelectionNumb) { carSelectedSprite.SetActive(false); }
        if (carNumb == carSelectionNumb) { carSelectedSprite.SetActive(true); }

        if (ButtonDoubleClickListener.doubleClick) { SelectCar(); }

        if (carSelectionNumb == 1) { car1_Menu.SetActive(true); }
        if (carSelectionNumb == 2) { car2_Menu.SetActive(true); }
        if (carSelectionNumb == 3) { car3_Menu.SetActive(true); }
        if (carSelectionNumb == 4) { car4_Menu.SetActive(true); }
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

        car1_Menu.SetActive(false);
        car2_Menu.SetActive(false);
        car3_Menu.SetActive(false);
        car4_Menu.SetActive(false);       
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

        if (carNumb == 2 && car2_save != 1 && menuCoinVal >= 270)
        {
            if (PlayerPrefs.GetInt("coin", 0) >= 270)
            {
                menuCoinVal -= 270;
                PlayerPrefs.SetInt("car2_saved", 1);
                PlayerPrefs.SetInt("coin", menuCoinVal);

                shopMenuUI.SetTrigger("carBuyed");
                Debug.Log("Buyed || car number: " + carNumb + " || Coin: " + PlayerPrefs.GetInt("coin", 0));
            }
        }
        if (carNumb == 3 && car4_save != 1 && menuCoinVal >= 740)
        {
            if (LevelController.coinSaved >= 740)
            {
                menuCoinVal -= 740;
                PlayerPrefs.SetInt("car3_saved", 1);
                PlayerPrefs.SetInt("coin", menuCoinVal);

                shopMenuUI.SetTrigger("carBuyed");
                Debug.Log("Buyed || car number: " + carNumb + " || Coin: " + PlayerPrefs.GetInt("coin", 0));
            }
        }
        if (carNumb == 4 && car4_save != 1 && menuCoinVal >= 4600)
        {
            if (LevelController.coinSaved >= 4600)
            {
                menuCoinVal -= 4600;
                PlayerPrefs.SetInt("car4_saved", 1);
                PlayerPrefs.SetInt("coin", menuCoinVal);

                shopMenuUI.SetTrigger("carBuyed");
                Debug.Log("Buyed || car number: " + carNumb + " || Coin: " + PlayerPrefs.GetInt("coin", 0));
            }
        }

        StartCoroutine(buyButtonDelay());
    }

    public void SelectCar()
    {
        if (carNumb == 1 && carSelectionNumb != 1)
        {
            carSelectionNumb = 1;
            Debug.Log("1 enter");
            shopMenuUI.SetTrigger("carSelect");
        }
        if (carNumb == 2 && car2_save == 1 && carSelectionNumb != 2)
        {
            carSelectionNumb = 2;
            Debug.Log("2 enter");
            shopMenuUI.SetTrigger("carSelect");
        }
        if (carNumb == 3 && car3_save == 1 && carSelectionNumb != 3)
        {
            carSelectionNumb = 3;
            Debug.Log("3 enter");
            shopMenuUI.SetTrigger("carSelect");
        }
        if (carNumb == 4 && car4_save == 1 && carSelectionNumb != 4)
        {
            carSelectionNumb = 4;
            Debug.Log("4 enter");
            shopMenuUI.SetTrigger("carSelect");
        }

        PlayerPrefs.SetInt("selectedCar", carSelectionNumb);
        Debug.Log("Car " + carSelectionNumb + " selected" + " || SavedCarNumb: " + PlayerPrefs.GetInt("selectedCar", 0));
        ButtonDoubleClickListener.doubleClick = false;
    }

    IEnumerator buyButtonDelay()
    {
        yield return new WaitForSeconds(0.5f);
        buyButtonPressed.SetActive(false);
        buyButtonNormal.SetActive(true);
    }
}
