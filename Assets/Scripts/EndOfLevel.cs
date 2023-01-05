using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using TMPro;

public class EndOfLevel : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    public int AmountOfPumpkingsRewardOnFinish;
    public Button ContinueButton;
    public Button MultiplyButton;
    public GameObject EndOfLevelPanel;
    public TMP_Text RewardAmount;
    public TMP_Text MultiplyReward;
    public int NextStage;
    
    // Start is called before the first frame update
    void Start()
    {
        ContinueButton.onClick.AddListener(Continue);
        MultiplyButton.onClick.AddListener(ShowBonusRewardVR);

        EndOfLevelPanel.SetActive(false);

        _gameEvents.OnEndOfLevel()
            .Subscribe(_ => FinishLevel())
            .AddTo(this);
        _gameEvents.OnGiveRewardBonus()
            .Subscribe(_ => Multiply())
            .AddTo(this);

        RewardAmount.text = AmountOfPumpkingsRewardOnFinish.ToString();
        MultiplyReward.text = (AmountOfPumpkingsRewardOnFinish*2).ToString();
    }

    void FinishLevel(){
        EndOfLevelPanel.SetActive(true);
        PlayerPrefs.SetInt("CurrentStage",NextStage);
    }

    void Continue(){
        _gameEvents.GiveReward(AmountOfPumpkingsRewardOnFinish);
        _gameEvents.LoadScene.OnNext("LevelSelection");
    }
    void ShowBonusRewardVR(){
        _gameEvents.ShowMultiplyRewardVR();
    }
    void Multiply(){
        int reward = AmountOfPumpkingsRewardOnFinish*2;
        _gameEvents.GiveReward(reward);
        _gameEvents.LoadScene.OnNext("LevelSelection");
    }
    

    
}
