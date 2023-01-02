using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class WaveTimer : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    public Slider Slider;
    public float WaitTime;
    bool _stopTimer;
    //bool _isWaitTimeEnded;
    public float WaveDuration;
    //float _elapsedTimeSinceStart;
    // Start is called before the first frame update
    void Start()
    {
        
        Slider.maxValue = WaveDuration;
        Slider.minValue = 0f;

        _gameEvents.OnGameOver()
            .Subscribe(_ => {
                _stopTimer = true;
            })
            .AddTo(this);
        _gameEvents.OnRevive()
            .Subscribe(_ => {
                _stopTimer = false;
            })
            .AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        /*if(!_isWaitTimeEnded){
            _elapsedTimeSinceStart += Time.deltaTime;
            
            if(_elapsedTimeSinceStart>= WaitTime)
                _isWaitTimeEnded = true;
        }*/

        if (!_stopTimer)
        {
            Slider.value += Time.deltaTime;
            if (Slider.value >= WaveDuration){
                _stopTimer = true;
                _gameEvents.OnEndWave();
            }
                
        }

    }
}
