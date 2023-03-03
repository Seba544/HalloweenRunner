using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGame : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    [SerializeField] Button _newGameButton;
    // Start is called before the first frame update
    void Start()
    {
        _newGameButton.onClick.AddListener(GoToNewGame);
    }

    void GoToNewGame(){
        int currentLevel = PlayerPrefs.GetInt("Apocalypse Current Stage ");
        if(currentLevel==0)
            PlayerPrefs.SetInt("Apocalypse Current Stage ",1);
        _gameEvents.LoadScene.OnNext("LevelSelection"); 
    }
}
