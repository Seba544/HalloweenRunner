using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToStage : MonoBehaviour
{
    public int Stage;
    [SerializeField] GameEvent _gameEvents;
    private Button StageButton;
    
    // Start is called before the first frame update
    void Start()
    {
        StageButton = GetComponent<Button>();
        StageButton.onClick.AddListener(Go);
    }

    void Go(){
        _gameEvents.LoadScene.OnNext("Stage"+Stage);
    }
}
