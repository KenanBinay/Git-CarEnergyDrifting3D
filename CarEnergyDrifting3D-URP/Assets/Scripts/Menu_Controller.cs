using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu_Controller : MonoBehaviour
{
    public AudioSource buttonClicking_sfx, uiPopUp_sfx, carSelected_sfx, buyCar_sfx;
    public Button button_TapToPLay, button_shop, button_settings, button_home, button_buy, button_R, button_L, button_sfx, button_settingsClose;
    public Animator shopIcon, homeMenuUI, shopMenuUI;
    public TextMeshProUGUI coinText, carPriceTxt;
    public GameObject mainMenu, shopMenu, buyButtonNormal, buyButtonPressed, settingsSprite,
           homeSprite, carSelectedSprite, car1_go, car2_go, car3_go, car4_go, car1_Menu, car2_Menu, car3_Menu, car4_Menu, settings_UI, sfxOff_sprite;
    public static int car1_save, car2_save, car3_save, car4_save;
    int carNumb, carPrice, carSelectionNumb, priceD, coinX, menuCoinVal;
    string sfxVal;
    void Start()
    {
        sfxVal = PlayerPrefs.GetString("sfx");

        priceD = coinX = 0;
        carNumb = 1;
        car1_save = 1;
        car2_save = PlayerPrefs.GetInt("car2_saved", 0);
        car3_save = PlayerPrefs.GetInt("car3_saved", 0);
        car4_save = PlayerPrefs.GetInt("car4_saved", 0);
        menuCoinVal = PlayerPrefs.GetInt("coin", 0);
        if (PlayerPrefs.GetInt("level_main") == 0) { LevelController.currentLevel = 1; }
        else { LevelController.currentLevel = PlayerPrefs.GetInt("level_main"); }      

        carPriceTxt.text = 0.ToString();
        shopMenu.SetActive(false);
        homeSprite.SetActive(false);
        car1_Menu.SetActive(false);
        car2_Menu.SetActive(false);
        car3_Menu.SetActive(false);
        car4_Menu.SetActive(false);
        settings_UI.SetActive(false);
        mainMenu.SetActive(true);
        settingsSprite.SetActive(true);
        homeMenuUI.enabled = true;
        shopMenuUI.enabled = false;

        if (PlayerPrefs.GetInt("selectedCar", 0) == 0) { carSelectionNumb = 1; }
        else { carSelectionNumb = PlayerPrefs.GetInt("selectedCar", 0); }

        Debug.Log("car1Save: " + car1_save + " || car2Save: " + car2_save + " || car3Save: " + car3_save + " || car4Save: " + car4_save);
        Debug.Log("SelectedCar: " + PlayerPrefs.GetInt("selectedCar") + " || Coin: " + PlayerPrefs.GetInt("coin", 0));
        Debug.Log("current level: " + LevelController.currentLevel);
    }

    void Update()
    {
        if (priceD != carPrice)
        {
            if (priceD > carPrice) { priceD -= 100; }
            if (priceD < carPrice) { priceD += 100; }
            carPriceTxt.text = priceD.ToString();
        }
        /*if (coinX != menuCoinVal)
        {
            if (coinX > menuCoinVal) { coinX -= 1; }
            if (coinX < menuCoinVal) { coinX += 1; }          
        }
        */
        coinText.text = menuCoinVal.ToString();

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

        button_sfx.onClick.AddListener(() => sfxSet());
        button_settingsClose.onClick.AddListener(() => closeSettings());

    }

    void shopLoad()
    {
        if (sfxVal == "on")
        {
            buttonClicking_sfx.Play();
            uiPopUp_sfx.PlayDelayed(0.12f);
        }

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
        if (sfxVal == "on")
        {
            buttonClicking_sfx.Play();
            uiPopUp_sfx.PlayDelayed(0.12f);
        }

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
        if (sfxVal == "on")
        {
            buttonClicking_sfx.Play();
            uiPopUp_sfx.PlayDelayed(0.12f);
        }
        else { sfxOff_sprite.SetActive(true); }

        settings_UI.SetActive(true);
        mainMenu.SetActive(false);
        settingsSprite.SetActive(false);
    }

    void closeSettings()
    {
        if (sfxVal == "on") { buttonClicking_sfx.Play(); }

        mainMenu.SetActive(true);
        settingsSprite.SetActive(true);
        settings_UI.SetActive(false);
    }

    void nextCarButtonL()
    {
        if (sfxVal == "on") { buttonClicking_sfx.Play(); }

        if (carNumb != 1) { carNumb--; }

        if (carNumb == 1)
        {
            carPrice = 0000;
            car1_go.SetActive(true);
            car2_go.SetActive(false);
        }
        if (carNumb == 2)
        {
            if (car2_save == 1) { carPrice = 0; }
            else { carPrice = 300; }

            car2_go.SetActive(true);
            car3_go.SetActive(false);
        }
        if (carNumb == 3)
        {
            if (car3_save == 1) { carPrice = 0; }
            else { carPrice = 800; }

            car3_go.SetActive(true);
            car4_go.SetActive(false);
        }

        Debug.Log("Car Number: " + carNumb + " || CarPriceSet: " + carPrice);
        shopMenuUI.SetTrigger("carShowing");
    }

    void nextCarButtonR()
    {
        if (sfxVal == "on") { buttonClicking_sfx.Play(); }

        if (carNumb != 4) { carNumb++; }

        if (carNumb == 2)
        {
            if (car2_save == 1) { carPrice = 0; }
            else { carPrice = 300; }

            car2_go.SetActive(true);
            car1_go.SetActive(false);
        }
        if (carNumb == 3)
        {
            if (car3_save == 1) { carPrice = 0; }
            else { carPrice = 800; }

            car3_go.SetActive(true);
            car2_go.SetActive(false);
        }
        if (carNumb == 4)
        {
            if (car4_save == 1) { carPrice = 0; }
            else { carPrice = 4600; }

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

        if (carNumb == 2)
        {
            if (car2_save == 0 && menuCoinVal >= 300)
            {
                if (sfxVal == "on") { buyCar_sfx.Play(); }

                menuCoinVal -= 300;
                carPrice = 0;
                PlayerPrefs.SetInt("car2_saved", 1);
                PlayerPrefs.SetInt("coin", menuCoinVal);

                shopMenuUI.SetTrigger("carBuyed");
                Debug.Log("Buyed || car number: " + carNumb + " || Coin: " + PlayerPrefs.GetInt("coin", 0));
            }
            else { Debug.Log("Can't Buyed || car number: " + carNumb + " || car2 save: " + car2_save + " || Coin: " + PlayerPrefs.GetInt("coin", 0)); }
        }

        if (carNumb == 3)
        {
            if (car3_save == 0 && menuCoinVal >= 800)
            {
                if (sfxVal == "on") { buyCar_sfx.Play(); }

                menuCoinVal -= 800;
                carPrice = 0;
                PlayerPrefs.SetInt("car3_saved", 1);
                PlayerPrefs.SetInt("coin", menuCoinVal);

                shopMenuUI.SetTrigger("carBuyed");
                Debug.Log("Buyed || car number: " + carNumb + " || Coin: " + PlayerPrefs.GetInt("coin", 0));
            }
            else { Debug.Log("Can't Buyed || car number: " + carNumb + " || car3 save: " + car3_save + " || Coin: " + PlayerPrefs.GetInt("coin", 0)); }
        }

        if (carNumb == 4)
        {
            if (car4_save == 0 && menuCoinVal >= 4600)
            {
                if (sfxVal == "on") { buyCar_sfx.Play(); }

                menuCoinVal -= 4600;
                carPrice = 0;
                PlayerPrefs.SetInt("car4_saved", 1);
                PlayerPrefs.SetInt("coin", menuCoinVal);

                shopMenuUI.SetTrigger("carBuyed");
                Debug.Log("Buyed || car number: " + carNumb + " || Coin: " + PlayerPrefs.GetInt("coin", 0));
            }
            else { Debug.Log("Can't Buyed || car number: " + carNumb + " || car4 save: " + car4_save + " || Coin: " + PlayerPrefs.GetInt("coin", 0)); }
        }

        StartCoroutine(buyButtonDelay());
    }

    public void SelectCar()
    {               
        if (carNumb == 1 && carSelectionNumb != 1)
        {
            if (sfxVal == "on") { carSelected_sfx.Play(); }

            carSelectionNumb = 1;
            Debug.Log("1 enter");
            shopMenuUI.SetTrigger("carSelect");
        }
        if (carNumb == 2 && car2_save == 1 && carSelectionNumb != 2)
        {
            if (sfxVal == "on") { carSelected_sfx.Play(); }

            carSelectionNumb = 2;
            Debug.Log("2 enter");
            shopMenuUI.SetTrigger("carSelect");
        }
        if (carNumb == 3 && car3_save == 1 && carSelectionNumb != 3)
        {
            if (sfxVal == "on") { carSelected_sfx.Play(); }

            carSelectionNumb = 3;
            Debug.Log("3 enter");
            shopMenuUI.SetTrigger("carSelect");
        }
        if (carNumb == 4 && car4_save == 1 && carSelectionNumb != 4)
        {
            if (sfxVal == "on") { carSelected_sfx.Play(); }

            carSelectionNumb = 4;
            Debug.Log("4 enter");
            shopMenuUI.SetTrigger("carSelect");
        }

        PlayerPrefs.SetInt("selectedCar", carSelectionNumb);
        Debug.Log("Car " + carSelectionNumb + " selected" + " || SavedCarNumb: " + PlayerPrefs.GetInt("selectedCar", 0));
        ButtonDoubleClickListener.doubleClick = false;
    }

    void sfxSet()
    {      
        if (sfxVal == "on")
        {           
            sfxVal = "off";
            sfxOff_sprite.SetActive(true);
            Debug.Log("sfx: " + sfxVal);

            PlayerPrefs.SetString("sfx", sfxVal);
        }
        else
        {
            buttonClicking_sfx.Play();

            sfxVal = "on"; ;
            sfxOff_sprite.SetActive(false);
            Debug.Log("sfx: " + sfxVal);

            PlayerPrefs.SetString("sfx",sfxVal);
        }
    }

    IEnumerator buyButtonDelay()
    {
        yield return new WaitForSeconds(0.5f);
        buyButtonPressed.SetActive(false);
        buyButtonNormal.SetActive(true);
    }
}
