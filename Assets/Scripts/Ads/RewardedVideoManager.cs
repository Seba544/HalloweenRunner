using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UniRx;
using TMPro;

public class RewardedVideoManager : MonoBehaviour,IUnityAdsLoadListener,IUnityAdsShowListener
{
    [SerializeField] GameEvent _gameEvents;
    string _extraLifePlacementId = "Extra_Life";
    string _multiplyRewardPlacementId = "Reward_Bonus";
    // Start is called before the first frame update
    void Start()
    {
        LoadVR();
        LoadRewardBonusVR();
        _gameEvents.OnShowExtraLifeVR()
            .Subscribe(_ => {
                
                ShowVR();
            })
            .AddTo(this);
        _gameEvents.OnShowMultiplyRewardVR()
            .Subscribe(_ => {
                ShowMultiplyRewardVR();
            })
            .AddTo(this);
    }

    
    void LoadVR() => Advertisement.Load(_extraLifePlacementId,this);
    void LoadRewardBonusVR() => Advertisement.Load(_multiplyRewardPlacementId,this);
    
    void ShowVR () => Advertisement.Show(_extraLifePlacementId,this); 
    void ShowMultiplyRewardVR() => Advertisement.Show(_multiplyRewardPlacementId,this);  
    
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Unity ad "+ placementId+" loaded successfully");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {placementId}: {error.ToString()} - {message}");
        if(placementId == _extraLifePlacementId)
            LoadVR();
        if(placementId == _multiplyRewardPlacementId)
            LoadRewardBonusVR();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId.Equals(_extraLifePlacementId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            
            _gameEvents.Revive();

            // Load another ad:
            Advertisement.Load(_extraLifePlacementId, this);
        }
        if(placementId.Equals(_multiplyRewardPlacementId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED)){
            _gameEvents.GiveRewardBonus();
        }
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        
        if(error == UnityAdsShowError.NO_CONNECTION || error == UnityAdsShowError.NOT_INITIALIZED){
            _gameEvents.ShowError();
        }
        else
        {
            if(placementId == _extraLifePlacementId){
                _gameEvents.Revive();
                Advertisement.Load(_extraLifePlacementId, this);
            }
            if(placementId==_multiplyRewardPlacementId)
                _gameEvents.GiveRewardBonus();

        }
        
        
        
        
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("The ad is now started");
    }

    
}
