using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectorManager : MonoBehaviour
{
    [SerializeField] StageSelectorConfiguration _config;
    [SerializeField] StageEnabler _firstWorldStageToUnlock;
    [SerializeField] GameEvent _gameEvents;
    public GameObject Grid;
    public Button UnlockButton;
    public TMP_Text PumpkingsRequiredTxt;
    public TMP_Text WorldName;
    public GameObject ComingSoonPanel;
    public Image Frame;
    // Start is called before the first frame update
    void Start()
    {
        UnlockButton.onClick.AddListener(Unlock);
        ComingSoonPanel.SetActive(false);
        UnlockButton.gameObject.SetActive(false);
        Grid.SetActive(false);
        WorldName.text = _config.WorldName;
        Frame.sprite = _config.Frame;
        PumpkingsRequiredTxt.text = "X"+_config.RequiredPumpkingsToUnlock;
        SetWorldAvailability();
    }

    void SetWorldAvailability(){
        if(!_config.IsUnlockable){
            Grid.SetActive(true);
            return;
        }
        if(_config.IsInDevelopment){
            Grid.SetActive(false);
            ComingSoonPanel.SetActive(true);
            return;
        }
        if(PlayerPrefs.GetString(_config.WorldName)=="unlocked"){
            Grid.SetActive(true);
            return;
        }
        if(PlayerPrefs.GetInt("Treasure") >= _config.RequiredPumpkingsToUnlock){
           
            UnlockButton.gameObject.SetActive(true);
            UnlockButton.interactable = true;
        }else{
            
            UnlockButton.gameObject.SetActive(true);
            UnlockButton.interactable = false;
        }
            
    }
    void Unlock(){
        int currentPumpkins = PlayerPrefs.GetInt("Treasure");
        int total = currentPumpkins - _config.RequiredPumpkingsToUnlock;
        UnlockButton.gameObject.SetActive(false);
        Grid.gameObject.SetActive(true);
        PlayerPrefs.SetString(_config.WorldName,"unlocked");
        WorldProgression worldProgression = new WorldProgression(_config.WorldName,new List<int>());
        SaveSystem.SaveWorldProgression(worldProgression);
        _firstWorldStageToUnlock.CheckAvailability();
        PlayerPrefs.SetInt("Treasure",total);
        _gameEvents.UpdateTreasureText(total.ToString());
        
    }
}
