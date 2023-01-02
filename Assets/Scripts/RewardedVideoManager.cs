using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UniRx;

public class RewardedVideoManager : MonoBehaviour,IUnityAdsLoadListener,IUnityAdsShowListener
{
    [SerializeField] GameEvent _gameEvents;
    string _extraLifePlacementId = "Extra_Life";
    // Start is called before the first frame update
    void Start()
    {
        LoadVR();
        _gameEvents.OnShowExtraLifeVR
            .Subscribe(_ => {
                
                ShowVR();
            })
            .AddTo(this);
    }

    
    void LoadVR() => Advertisement.Load(_extraLifePlacementId,this);
    
    void ShowVR () => Advertisement.Show(_extraLifePlacementId,this);   
    
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Unity ad "+ placementId+" loaded successfully");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {placementId}: {error.ToString()} - {message}");
       
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId.Equals(_extraLifePlacementId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            _gameEvents.Revive();

            // Load another ad:
            Advertisement.Load(_extraLifePlacementId, this);
        }
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {placementId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("The ad is now started");
    }

    
}
