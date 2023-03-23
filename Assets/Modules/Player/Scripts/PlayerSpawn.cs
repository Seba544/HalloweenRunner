using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    [SerializeField] List<SkinConfiguration> _skinConfigurations;
    [SerializeField] GameObject _spawnPoint;
    private SkinConfiguration _currentSkin; 
    
    void Start()
    {
        SpawnPlayer();
        Destroy(this.gameObject);
    }

    void SpawnPlayer(){
        PlayerSkinData playerSkinData = SaveSystem.LoadPlayerSkins();
       
        if(playerSkinData==null){
            _currentSkin = _skinConfigurations.Where(skin => skin.SkinID == "pumpkin_head").First();
            playerSkinData = new PlayerSkinData(_currentSkin.SkinID,new List<string>{_currentSkin.SkinID});
            SaveSystem.SavePlayerSkin(playerSkinData);
            Instantiate(_currentSkin.Player,_spawnPoint.transform.position,Quaternion.identity);
        }else{
            _currentSkin = _skinConfigurations.Where(skin => skin.SkinID == playerSkinData.CurrentSkin).First();
            Instantiate(_currentSkin.Player,_spawnPoint.transform.position,Quaternion.identity);
            
        }
        
    }
    void OnDestroy()
    {
        _gameEvents.FollowPlayer();
    }
}
