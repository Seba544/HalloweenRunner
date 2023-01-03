using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectorManager : MonoBehaviour
{
    public GameObject Grid;
    public int PumpkingsRequired;
    public Button UnlockButton;
    public TMP_Text PumpkingsRequiredTxt;
    // Start is called before the first frame update
    void Start()
    {
        PumpkingsRequiredTxt.text = "X"+PumpkingsRequired;
        SetWorldAvailability();
    }

    void SetWorldAvailability(){
        if(PlayerPrefs.GetInt("Pumpkings") >= PumpkingsRequired){
            Grid.SetActive(true);
            UnlockButton.gameObject.SetActive(false);
        }else{
            Grid.SetActive(false);
            UnlockButton.gameObject.SetActive(true);
        }
            
    }
}
