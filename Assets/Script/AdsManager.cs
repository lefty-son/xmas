using System;
using System.Collections;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour
{

    public static AdsManager instance;

    public GameObject freeHeartPanel;

    public int adType;



    [SerializeField] private string appId;
    [SerializeField] private RewardBasedVideoAd rewardBasedVideo;
    [SerializeField] private BannerView bannerView;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    // Use this for initialization
    void Start()
    {
#if UNITY_ANDROID
        appId = "ca-app-pub-8860756584846944~9021298535";
#elif UNITY_IPHONE
        appId = "ca-app-pub-8860756584846944~2155796845";
#else
        appId = "UNKNOWN_PLATFORM";
#endif

#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-8860756584846944/6335882298";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-8860756584846944/1811024368";
#else
        string adUnitId = "unexpected_platform";
#endif

        MobileAds.Initialize(appId);

        #region BANNER AD

        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        // Called when an ad request has successfully loaded.
        bannerView.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        bannerView.OnAdOpening += HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        bannerView.OnAdClosed += HandleOnAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().
        AddTestDevice(AdRequest.TestDeviceSimulator).
        AddTestDevice("07EB17C47DEAD7454116C04CDF20E1C5").
        Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);
        HideBanner();
        //ShowBanner();

        #endregion

        adType = 0;

        // Get singleton reward based video ad reference.
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
        rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

        this.RequestRewardedVideo();

    }

    public void ShowBanner(){
        bannerView.Show();
    }

    public void HideBanner(){
        bannerView.Hide();
    }

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
    }

    public void HandleOnAdLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeftApplication event received");
    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        this.RequestRewardedVideo();
        GameManager.instance.adViewd = false;
        MonoBehaviour.print(
            "HandleRewardBasedVideoFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
        this.RequestRewardedVideo();
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        if(adType == 0){
            GameManager.instance.adViewd = true;
            BoxShaker.instance.GetOnce();
        }
        else {
            RewardEventAds.instance.Hide();
            freeHeartPanel.SetActive(true);
        }

    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }
	
    public void RequestRewardedVideo(){
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-8860756584846944/1725262447";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-8860756584846944/8828305964";
#else
        string adUnitId = "UNKNOWN_PLATFORM";
#endif

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("07EB17C47DEAD7454116C04CDF20E1C5")
.Build();
        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, adUnitId);
    }

    public void ShowRewardedVideo(int _value){
        if (rewardBasedVideo.IsLoaded())
        {
            adType = _value;
            rewardBasedVideo.Show();
        }
    }

    public void ShowFreeHeart(){
        if (rewardBasedVideo.IsLoaded())
        {
            adType = 1;
            rewardBasedVideo.Show();
        }
    }
}
