using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UniRx;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private bool _testMode = false;
    // Start is called before the first frame update
    void Awake()
    {
        Advertisement.Initialize("5099001",_testMode,this);
        
        
    }
    
    public void OnInitializationComplete()
    {
        Debug.Log("Ads initialized successfully");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
         Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    
}
