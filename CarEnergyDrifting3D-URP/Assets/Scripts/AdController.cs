using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class AdController : MonoBehaviour
{
    public GameObject x2AdObject;
    public Button x2AdButton;
    bool x2ButtonCheck;

    private InterstitialAd AdPlain;
    private RewardedAd AdRewarded;
    string idPlain, idRewarded;

    void Start()
    {
        x2AdObject.SetActive(false);

        x2ButtonCheck = false;

        idPlain = "ca-app-pub-9421503984483424/7677277793";
        idRewarded = "ca-app-pub-9421503984483424/1495012820";

    }

    void Update()
    {

        if (LevelEndUI_Controller.x2AdSprite)
        {

            if (LevelEndUI_Controller.x2AdSprite)
            {
                AdPlain = new InterstitialAd(idPlain);
                AdPlain.LoadAd(AdRequestBuild());

                if (x2ButtonCheck == false)
                {
                    x2AdObject.SetActive(true);
                    x2AdButton.onClick.AddListener(() => x2RewardedAd());
                }
            }

        }
    }

    void x2RewardedAd()
    {

        if (AdPlain.IsLoaded()) { AdPlain.Show(); }
    }

    public void HandleOnAdLoaded(object sender, EventArgs args) { }
    public void HandleOnAdOpening(object sender, EventArgs args) { }
    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        AdPlain.OnAdLoaded -= this.HandleOnAdLoaded;
        AdPlain.OnAdOpening -= this.HandleOnAdOpening;
        AdPlain.OnAdClosed -= this.HandleOnAdClosed;

        Debug.Log("x2 Coin = " + CarController.coinVal);

        CarController.coinVal *= 2;
        x2ButtonCheck = true;
        LevelEndUI_Controller.x2AdSprite = false;
    }

    AdRequest AdRequestBuild()
    {
        return new AdRequest.Builder().Build();
    }
}
