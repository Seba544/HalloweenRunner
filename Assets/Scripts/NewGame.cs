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
        
            if(SaveSystem.LoadWorldProgression("Apocalypse")==null){
                WorldProgression worldProgression = new WorldProgression("Apocalypse",new List<int>());
                SaveSystem.SaveWorldProgression(worldProgression);
            }
        
            
           
        _gameEvents.LoadScene.OnNext("LevelSelection"); 
    }
}
