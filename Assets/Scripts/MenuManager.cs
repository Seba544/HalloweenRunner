using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    [SerializeField] Button _newGameButton;
    [SerializeField] Button _skinsButton;
    private PlayerSkinData _playerSkinData;
    // Start is called before the first frame update
    void Start()
    {
        _newGameButton.onClick.AddListener(GoToNewGame);
        _skinsButton.onClick.AddListener(GoToSkinsSelection);
        FirstSkinValidation();
    }

    void GoToNewGame(){
        
            if(SaveSystem.LoadWorldProgression("Apocalypse")==null){
                WorldProgression worldProgression = new WorldProgression("Apocalypse",new List<int>());
                SaveSystem.SaveWorldProgression(worldProgression);
            }

           
        _gameEvents.LoadScene.OnNext("LevelSelection"); 
    }
    void GoToSkinsSelection(){
        _gameEvents.LoadScene.OnNext("SkinSelection"); 
    }
    void FirstSkinValidation(){
        _playerSkinData = SaveSystem.LoadPlayerSkins();
        if(_playerSkinData==null){
                _playerSkinData = new PlayerSkinData("pumpkin_head",new List<string>{"pumpkin_head"});
                SaveSystem.SavePlayerSkin(_playerSkinData);
            }
    }
}
