using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    private Button Button;
    public string GoTo;
    // Start is called before the first frame update
    void Start()
    {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(Go);
    }
    void Go(){
        if(!string.IsNullOrEmpty(GoTo)){
            _gameEvents.LoadScene.OnNext(GoTo);
        }
        
    }

}
