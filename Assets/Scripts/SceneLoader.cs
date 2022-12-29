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
        _gameEvents.LoadScene
            .Subscribe(sceneToLoad => {
                if(!String.IsNullOrEmpty(sceneToLoad)){
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
