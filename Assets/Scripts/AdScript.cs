﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdScript : MonoBehaviour
{
    string AppId = "ca-app-pub-5870321000407115~2591904242";
    string InterestitialAdID = "ca-app-pub-5870321000407115/3157158251";//test: ca-app-pub-3940256099942544/1033173712 //Realad: ca-app-pub-5870321000407115/3486072145
    string BannerAdId = "ca-app-pub-3940256099942544/6300978111";
    string RewardAd = "ca-app-pub-3940256099942544/5224354917";

    private InterstitialAd interstitial;
    private RewardedAd rewardedAd;
    //private BannerView bannerView;
    void Start()
    {

        MobileAds.Initialize(AppId);
        //RequestBannerAd();
        if (Application.platform == RuntimePlatform.Android)
        {
            RequestInterstitial();
        }
    }

    private void RequestInterstitial()
    {
        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(InterestitialAdID);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    private void RequestBannerAd()
    {/*
        this.bannerView = new BannerView(BannerAdId, AdSize.Banner, AdPosition.Top);
        // Create an empty ad request.

        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.bannerView.OnAdClosed += this.HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;

        */
    }

   

    public void ShowinterstitialAds()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }

    public void ShowbannerViewAds()
    {
        //AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
       // this.bannerView.LoadAd(request);
    }

    public void ShowRequesAds()
    {

    }

    #region interstitial and banned handler

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
        RequestInterstitial();
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    #endregion

}
