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
    public TMP_Text Description;
    public string World;
    public int NextStage;
    private int AmountOfPumpkinsRewardLevelRepeated = 50;
    bool isPlayerDead;
    private int Stage;
    // Start is called before the first frame update
    void Start()
    {
        Stage = NextStage-1;
        ContinueButton.onClick.AddListener(Continue);
        MultiplyButton.onClick.AddListener(ShowBonusRewardVR);

        EndOfLevelPanel.SetActive(false);
        _gameEvents.OnShowExtraLifeVR()
            .Subscribe(_ => {
                isPlayerDead = false;
            })
            .AddTo(this);

        _gameEvents.OnGameOver()
            .Subscribe(_ => {
                isPlayerDead = true;
            })
            .AddTo(this);
        _gameEvents.OnEndOfLevel()
            .Subscribe(_ => FinishLevel())
            .AddTo(this);
        _gameEvents.OnGiveRewardBonus()
            .Subscribe(_ => Multiply())
            .AddTo(this);
        int currentStage = PlayerPrefs.GetInt("CurrentStage");
        WorldProgression worldProgression = SaveSystem.LoadWorldProgression(World);
        if(worldProgression!= null && worldProgression.LevelsCompleted.Contains(Stage)){
            AmountOfPumpkingsRewardOnFinish = AmountOfPumpkinsRewardLevelRepeated;
            Description.text = "Try to play new levels to get more pumpkins!";
        }
        RewardAmount.text = AmountOfPumpkingsRewardOnFinish.ToString();
        MultiplyReward.text = (AmountOfPumpkingsRewardOnFinish*2).ToString();
    }

    void FinishLevel(){
        if(isPlayerDead)
            return;
        EndOfLevelPanel.SetActive(true);
        WorldProgression worldProgression = SaveSystem.LoadWorldProgression(World);
        if(worldProgression!=null && !worldProgression.LevelsCompleted.Contains(Stage)){
            worldProgression.LevelsCompleted.Add(Stage);
            SaveSystem.SaveWorldProgression(worldProgression);
        }
        
    }

    void Continue(){
        _gameEvents.GiveReward(AmountOfPumpkingsRewardOnFinish);
        _gameEvents.ShowNextStageInstertitial();
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
