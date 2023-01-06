using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UniRx;

public class BannerManager : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    [SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;
    

    [SerializeField] string _androidAdUnitId = "Home_Banner_Android";
    [SerializeField] string _iOSAdUnitId = "Banner_iOS";
    string _adUnitId = null;
    
    void Awake()
    {
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif
    Advertisement.Banner.SetPosition(_bannerPosition);
    
    
    }
    void Start()
    {
        _gameEvents.OnHideBanner()
            .Subscribe(_ => {
                HideBannerAd();
            })
            .AddTo(this);
            
        LoadBanner();
    }

    public void LoadBanner()
    {
        // Set up options to notify the SDK of load events:
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };
 
        // Load the Ad Unit with banner content:
        Advertisement.Banner.Load(_adUnitId, options);
    }
    
    void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
        // Optionally execute additional code, such as attempting to load another ad.
    }
    void OnBannerLoaded()
    {
        Debug.Log("Banner loaded");
        
           ShowBannerAd();
    }
    void ShowBannerAd()
    {
        // Set up options to notify the SDK of show events:
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };
 
        // Show the loaded Banner Ad Unit:
        Advertisement.Banner.Show(_adUnitId, options);
    }
 
    // Implement a method to call when the Hide Banner button is clicked:
    void HideBannerAd()
    {
        // Hide the banner:
        Advertisement.Banner.Hide();
    }
    void OnBannerClicked() { }
    void OnBannerShown() { }
    void OnBannerHidden() { }
    
}
