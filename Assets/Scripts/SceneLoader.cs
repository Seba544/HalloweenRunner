using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
        Time.timeScale=1f;
        _gameEvents.LoadScene
            .Subscribe(sceneToLoad => {
                if(!String.IsNullOrEmpty(sceneToLoad)){
                    _gameEvents.HideBanner();
                    StartCoroutine(Load(sceneToLoad));
                }
            })
            .AddTo(this);
    }

    IEnumerator Load(string sceneToLoad){
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        while(!asyncLoad.isDone){
            yield return null;
        }
        
    }
}
