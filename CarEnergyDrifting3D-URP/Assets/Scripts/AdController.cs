using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

public class AdController : MonoBehaviour
{
    public GameObject x2AdObject;
    public Button x2AdButton;
    public static bool x2ButtonCheck;
    bool adRewardedControl;

    private InterstitialAd adInterstitial;
    private RewardedAd adRewarded;
    string idInterstitial, idRewarded;

    void Start()
    {
        x2AdObject.SetActive(false);
        x2ButtonCheck = adRewardedControl = false;

        idInterstitial = "ca-app-pub-9421503984483424/7677277793";
        idRewarded = "ca-app-pub-9421503984483424/1495012820";

        this.adRewarded = new RewardedAd(idRewarded);

        AdRequest request = new AdRequest.Builder().Build();
        this.adRewarded.LoadAd(request);

        MobileAds.Initialize(initStatus => { });       
    }

    void Update()
    {       
        if (this.adRewarded.IsLoaded())
        {
            if (LevelEndUI_Controller.x2AdSprite)
            {
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
        if (adRewardedControl == false)
        {
            adRewarded.OnAdLoaded += this.HandleOnRewardedAdLoaded;
            adRewarded.OnAdOpening += this.HandleOnRewardedAdOpening;
            adRewarded.OnAdClosed += this.HandleOnRewardedAdClosed;

            adRewardedControl = true;
            this.adRewarded.Show();
        }
    }

    public void HandleOnRewardedAdLoaded(object sender, EventArgs args) {  }
    public void HandleOnRewardedAdOpening(object sender, EventArgs args) { }
    public void HandleOnRewardedAdClosed(object sender, EventArgs args)
    {

        CarController.coinVal *= 2;
        Debug.Log("x2 Coin = " + CarController.coinVal);

        x2ButtonCheck = true;
        LevelEndUI_Controller.x2AdSprite = false;
       
        adInterstitial.OnAdLoaded -= this.HandleOnRewardedAdLoaded;
        adInterstitial.OnAdOpening -= this.HandleOnRewardedAdOpening;
        adInterstitial.OnAdClosed -= this.HandleOnRewardedAdClosed;
    }

    AdRequest AdRequestBuild()
    {
        return new AdRequest.Builder().Build();
    }
}
