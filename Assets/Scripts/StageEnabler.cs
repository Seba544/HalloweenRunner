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
    public string World;
    private Image _icon;
    public Sprite AvailableIcon;
    public Sprite BlockedIcon;
    private TMP_Text StageNumber;
    private Button _stageButton;
    // Start is called before the first frame update
    void Start()
    {
        
        _icon = GetComponent<Image>();
        _stageButton = GetComponent<Button>();
        _stageButton.onClick.AddListener(Go);
        StageNumber = GetComponentInChildren<TMP_Text>();
        StageNumber.text = Stage.ToString();
        CheckAvailability();
    }
   
    public void CheckAvailability()
    {
        
        if (IsEnabled())
        {
            _icon.sprite = AvailableIcon;
            _stageButton.interactable = true;
        
                //transform.DOPunchScale(new Vector3(0.3f, 0.3f, 0.3f), 5, 2).SetLoops(30);
        }
        else
        {
            _icon.sprite = BlockedIcon;
            StageNumber.gameObject.SetActive(false);
            _stageButton.interactable = false;
        }
    }

    bool IsEnabled()
    {
        WorldProgression worldProgression = SaveSystem.LoadWorldProgression(World);
        if(worldProgression==null){
            return false;
        }
        if(worldProgression.LevelsCompleted.Count==0 && Stage == 1)
            return true;
        if(worldProgression.LevelsCompleted.Contains(Stage) || worldProgression.LevelsCompleted.Contains(Stage-1))
            return true;
        
        return false;
    }
    void Go()
    {
        _gameEvents.LoadScene.OnNext(World+"_"+Stage);
    }
}
