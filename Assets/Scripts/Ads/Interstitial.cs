using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UniRx;

public class Interstitial : MonoBehaviour,IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] GameEvent _gameEvents;
    string _androidAdUnitId = "Interstitial_Android";
    string _iOsAdUnitId = "Interstitial_iOS";
    string _androidNextStageId = "Next_Stage_Interstitial_Android";
    string _adUnitId;
 
    void Awake()
    {
        // Get the Ad Unit ID for the current platform:
        #if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif
    }
 void Start()
 {
    _gameEvents.OnShowInterstitial
        .Subscribe(_ => ShowAd())
        .AddTo(this);
    _gameEvents.OnShowNextStageInstertitial
        .Subscribe(_ => ShowNextStageAd())
        .AddTo(this);

    LoadAd();
    LoadNextStageAd();
 }
    // Load content to the Ad Unit:
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }
    public void LoadNextStageAd(){
        Advertisement.Load(_androidNextStageId,this);
    }
 
    // Show the loaded content in the Ad Unit:
    public void ShowAd()
    {
        
        Advertisement.Show(_adUnitId, this);
    }
    public void ShowNextStageAd(){
        Advertisement.Show(_androidNextStageId, this);
    }
 
    // Implement Load Listener and Show Listener interface methods: 
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        // Optionally execute code if the Ad Unit successfully loads content.
    }
 
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {adUnitId} - {error.ToString()} - {message}");
        if(adUnitId == _adUnitId)
            LoadAd();
        if(adUnitId == _androidNextStageId)
            LoadNextStageAd();
    }
 
    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to show, such as loading another ad.
        if(adUnitId == _adUnitId)
            _gameEvents.LoadScene.OnNext("Home");
        if(adUnitId == _androidNextStageId)
            _gameEvents.LoadScene.OnNext("LevelSelection");
    }
 
    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState) {
        if(adUnitId == _adUnitId)
            _gameEvents.LoadScene.OnNext("Home");
        if(adUnitId == _androidNextStageId)
            _gameEvents.LoadScene.OnNext("LevelSelection");
     }
}
