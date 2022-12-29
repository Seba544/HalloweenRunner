using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    // Start is called before the first frame update
    void Start()
    {
        _gameEvents.PauseGame()
            .Subscribe(_ => Pause())
            .AddTo(this);

        _gameEvents.ResumeGame()
            .Subscribe(_ => Resume())
            .AddTo(this);
            
    }

    void Pause(){
        Time.timeScale = 0f;
        
    }
    void Resume(){
        Time.timeScale = 1f;
    }
}
