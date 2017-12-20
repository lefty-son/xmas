using System;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour
{

    public static AdsManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    [SerializeField] private string appId;
    [SerializeField] private RewardBasedVideoAd rewardBasedVideo;

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

        MobileAds.Initialize(appId);

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

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        this.RequestRewardedVideo();
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
        string type = args.Type;
        double amount = args.Amount;
        Debug.Log("##################");
        Debug.Log(amount.ToString());
        Debug.Log(amount);
        Debug.Log("##################");
        MonoBehaviour.print(
            "HandleRewardBasedVideoRewarded event received for "
                        + amount.ToString() + " " + type);
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

    public void ShowRewardedVideo(){
        if (rewardBasedVideo.IsLoaded())
        {
            Debug.Log("SS");
            rewardBasedVideo.Show();
        }
    }
}
