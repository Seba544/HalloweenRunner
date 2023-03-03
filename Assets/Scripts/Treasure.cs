using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UniRx;

public class Treasure : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    public TMP_Text PumpkingsAmount;
    private int _pumpkingsCollected;
    // Start is called before the first frame update
    void Start()
    {
        _gameEvents.OnGiveReward()
            .Subscribe(pumpkingsAmount => SaveTreasure(pumpkingsAmount))
            .AddTo(this);
        _gameEvents.OnUpdateTreasureText()
            .Subscribe(pumpkins => UpdateTreasureText(pumpkins))
            .AddTo(this);
        _gameEvents.CollectPumpking()
    .Subscribe(_ => Collect());

        LoadTreasure();
    }
    void LoadTreasure()
    {
        int treasure = PlayerPrefs.GetInt("Treasure");
        PumpkingsAmount.text = treasure.ToString();
        _pumpkingsCollected = treasure;
    }
    void SaveTreasure(int pumpkingsAmountReward)
    {
        int totalTreasure = pumpkingsAmountReward + _pumpkingsCollected;
        PlayerPrefs.SetInt("Treasure", totalTreasure);
    }
    void Collect()
    {
        _pumpkingsCollected++;
        PumpkingsAmount.text = _pumpkingsCollected.ToString();
    }
    void UpdateTreasureText(string pumpkins){
        PumpkingsAmount.text = pumpkins;
    }
}
