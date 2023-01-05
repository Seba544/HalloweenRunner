using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PausePanel : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    public GameObject PausePopUp;
    // Start is called before the first frame update
    void Start()
    {
        PausePopUp.SetActive(false);
        _gameEvents.PauseGame()
            .Subscribe(_ => ShowPausePopUp())
            .AddTo(this);
        _gameEvents.ResumeGame()
            .Subscribe(_ => HidePausePopUp())
            .AddTo(this);
    }

    void ShowPausePopUp(){
        PausePopUp.SetActive(true);
        Time.timeScale = 0f;
    }
    void HidePausePopUp(){
        PausePopUp.SetActive(false);
        Time.timeScale = 1f;
    }
}
