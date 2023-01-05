using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class PauseButton : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    private Button _button;
    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Pause);
    }

    void Pause(){
        _gameEvents.PauseGame();
    }
    
}
