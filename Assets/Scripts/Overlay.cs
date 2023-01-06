using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Overlay : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    public GameObject OverlayPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameEvents.OnShowFtue()
            .Subscribe(_ => ToggleOverlay(true))
            .AddTo(this);
        _gameEvents.OnHideFtue()
            .Subscribe(_=>ToggleOverlay(false));
        _gameEvents.OnGameOver()
            .Subscribe(_ => ToggleOverlay(true))
            .AddTo(this);
        _gameEvents.OnEndOfLevel()
            .Subscribe(_ => ToggleOverlay(true))
            .AddTo(this);
        _gameEvents.PauseGame()
            .Subscribe(_ => ToggleOverlay(true))
            .AddTo(this);
        _gameEvents.ResumeGame()
            .Subscribe(_ => ToggleOverlay(false))
            .AddTo(this);
        _gameEvents.OnRevive()
            .Subscribe(_ => ToggleOverlay(false))
            .AddTo(this);
        ToggleOverlay(false);
        
    }

    void ToggleOverlay(bool isEnabled) => OverlayPanel.SetActive(isEnabled);
}
