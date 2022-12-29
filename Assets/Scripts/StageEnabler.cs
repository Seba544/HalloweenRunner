using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StageEnabler : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    public int Stage;
    private Image _icon;
    public Sprite AvailableIcon;
    public Sprite BlockedIcon;
    private TMP_Text StageNumber;
    private Button _stageButton;
    private int _currentStage;
    // Start is called before the first frame update
    void Start()
    {
        _currentStage = PlayerPrefs.GetInt("CurrentStage");
        _icon = GetComponent<Image>();
        _stageButton = GetComponent<Button>();
        _stageButton.onClick.AddListener(Go);
        StageNumber = GetComponentInChildren<TMP_Text>();
        StageNumber.text = Stage.ToString();
        if(IsEnabled()){
            _icon.sprite = AvailableIcon;
            _stageButton.interactable=true;
            if(_currentStage == Stage)
                transform.DOPunchScale(new Vector3(0.3f,0.3f,0.3f),5,2).SetLoops(30);
        }else{
            _icon.sprite = BlockedIcon;
            _stageButton.interactable=false;
        }
    }

    bool IsEnabled(){
        return _currentStage >= Stage; 
    }
    void Go(){
        _gameEvents.LoadScene.OnNext("Stage"+Stage);
    }
}
