using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectorManager : MonoBehaviour
{
    [SerializeField] StageSelectorConfiguration _config;
    public GameObject Grid;
    public Button UnlockButton;
    public TMP_Text PumpkingsRequiredTxt;
    public TMP_Text WorldName;
    public GameObject ComingSoonPanel;
    public Image Frame;
    // Start is called before the first frame update
    void Start()
    {
        ComingSoonPanel.SetActive(false);
        UnlockButton.gameObject.SetActive(false);
        WorldName.text = _config.WorldName;
        Frame.sprite = _config.Frame;
        PumpkingsRequiredTxt.text = "X"+_config.RequiredPumpkingsToUnlock;
        SetWorldAvailability();
    }

    void SetWorldAvailability(){
        if(_config.IsInDevelopment){
            Grid.SetActive(false);
            ComingSoonPanel.SetActive(true);
            return;
        }
        if(PlayerPrefs.GetInt("Pumpkings") >= _config.RequiredPumpkingsToUnlock){
            Grid.SetActive(true);
            UnlockButton.gameObject.SetActive(false);
        }else{
            Grid.SetActive(false);
            UnlockButton.gameObject.SetActive(true);
        }
            
    }
}
