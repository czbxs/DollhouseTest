/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

//using System;
//using UnityEngine;
//using System.Collections;
//
//// Google ads
//using GoogleMobileAds;
//using GoogleMobileAds.Api;
//
//public class GoogleAdsController : MonoBehaviour 
//{
//    public static GoogleAdsController instance = null;
//
//	[Header ("Admob Units")]
//	public BannerView bannerView;
//	public InterstitialAd interstitial;
//
//	// Use this for initialization
//    void Awake()
//    {
//        if (instance == null)
//        {
//            instance = this;
//        }
//        else if (instance != null)
//        {
//            Destroy(gameObject);
//        }
//
//        DontDestroyOnLoad(gameObject);
//    }
//
//    public void RequestBanner()
//    {
//#if UNITY_EDITOR
//        string adUnitId = "unused";
//#elif UNITY_ANDROID
//        string adUnitId = "INSERT_ANDROID_BANNER_AD_UNIT_ID_HERE";
//#elif UNITY_IPHONE
//        string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
//#else
//        string adUnitId = "unexpected_platform";
//#endif
//        // Create a banner.
//        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);
//
//        // Register for ad events.
//		bannerView.OnAdLoaded += HandleAdLoaded;
//		bannerView.OnAdFailedToLoad += HandleAdFailedToLoad;
//		bannerView.OnAdOpening += HandleAdOpened;
//		bannerView.OnAdClosed += HandleAdClosing;
//		bannerView.OnAdClosed += HandleAdClosed;
//		bannerView.OnAdLeavingApplication += HandleAdLeftApplication;
//        
//        // Load a banner ad.
//        bannerView.LoadAd(createAdRequest());
//    }
//
//    public void ShowBanner()
//    {
//        bannerView.Show();
//    }
//
//    public void HideBanner()
//    {
//        bannerView.Hide();
//    }
//
//
//		// Unity admob interstitial ads
//
//
//    public void RequestInterstitial()
//    {
//        // http://stackoverflow.com/questions/12553929/is-there-any-admob-dummy-id
//#if UNITY_EDITOR
//        string adUnitId = "unused";
//#elif UNITY_ANDROID
//        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
//#elif UNITY_IPHONE
//        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
//#else
//        string adUnitId = "unexpected_platform";
//#endif
//
//        // Create an interstitial.
//        interstitial = new InterstitialAd(adUnitId);
//
//        // Register for ad events.
//		interstitial.OnAdLoaded += HandleInterstitialLoaded;
//		interstitial.OnAdFailedToLoad += HandleInterstitialFailedToLoad;
//		interstitial.OnAdOpening += HandleInterstitialOpened;
//		interstitial.OnAdClosed += HandleInterstitialClosing;
//		interstitial.OnAdClosed += HandleInterstitialClosed;
//		interstitial.OnAdLeavingApplication += HandleInterstitialLeftApplication;
//        
//        // Load an interstitial ad.
//        interstitial.LoadAd(createAdRequest());
//    }
//
//    // Returns an ad request with custom ad targeting.
//    private AdRequest createAdRequest()
//    {
//        return new AdRequest.Builder()
//            //.AddTestDevice(AdRequest.TestDeviceSimulator)
//            .AddTestDevice("358C650724C178EEF6A9F24E3CCB5002")
//            //.AddKeyword("game")
//            //.SetGender(Gender.Male)
//            //.SetBirthday(new DateTime(1985, 1, 1))
//            //.TagForChildDirectedTreatment(false)
//            //.AddExtra("color_bg", "9B30FF")
//            .Build();
//    }
//
//    public void ShowInterstitial()
//    {
//        if (interstitial.IsLoaded())
//        {
//            interstitial.Show();
//        }
//        else
//        {
//            //print("Google Ads: Interstitial is not ready yet.");
//        }
//
//        RequestInterstitial();
//    }
//
//    #region Banner callback handlers
//
//    public void HandleAdLoaded(object sender, EventArgs args)
//    {
//        //print("Google Ads: HandleAdLoaded event received.");
//    }
//
//    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
//    {
//        //print("Google Ads: HandleFailedToReceiveAd event received with message: " + args.Message);
//    }
//
//    public void HandleAdOpened(object sender, EventArgs args)
//    {
//        //print("Google Ads: HandleAdOpened event received");
//    }
//
//    void HandleAdClosing(object sender, EventArgs args)
//    {
//        //print("Google Ads: HandleAdClosing event received");
//    }
//
//    public void HandleAdClosed(object sender, EventArgs args)
//    {
//        //print("Google Ads: HandleAdClosed event received");
//    }
//
//    public void HandleAdLeftApplication(object sender, EventArgs args)
//    {
//        //print("Google Ads: HandleAdLeftApplication event received");
//    }
//
//    #endregion
//
//    #region Interstitial callback handlers
//
//    public void HandleInterstitialLoaded(object sender, EventArgs args)
//    {
//        //print("Google Ads: HandleInterstitialLoaded event received.");
//    }
//
//    public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
//    {
//        //print("Google Ads: HandleInterstitialFailedToLoad event received with message: " + args.Message);
//    }
//
//    public void HandleInterstitialOpened(object sender, EventArgs args)
//    {
//        //print("Google Ads: HandleInterstitialOpened event received");
//    }
//
//    void HandleInterstitialClosing(object sender, EventArgs args)
//    {
//        //print("Google Ads: HandleInterstitialClosing event received");
//    }
//
//    public void HandleInterstitialClosed(object sender, EventArgs args)
//    {
//        //print("Google Ads: HandleInterstitialClosed event received");
//    }
//
//    public void HandleInterstitialLeftApplication(object sender, EventArgs args)
//    {
//        //print("Google Ads: HandleInterstitialLeftApplication event received");
//    }
//
//    #endregion
//}
