using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FTUEManager : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    [SerializeField] Button _jumpButtonContinue;
    [SerializeField] Button _slideButtonContinue;
    [SerializeField] Button _collectButtonContinue;
    [SerializeField] Button _killMonstersButtonContinue;

    public GameObject FtueJumpPanel;
    public GameObject FtueSlidePanel;
    public GameObject FtueCollectPanel;
    public GameObject FtueKillMonsters;
    
    // Start is called before the first frame update
    void Start()
    {
        _jumpButtonContinue.onClick.AddListener(GoToSlidePanel);
        _slideButtonContinue.onClick.AddListener(GoToKillMonstersPanel);
        _killMonstersButtonContinue.onClick.AddListener(GoToCollectPanel);
        _collectButtonContinue.onClick.AddListener(DestroyFtue);
        if(PlayerPrefs.GetInt("FTUE")==0){
            StartCoroutine(PlayTutorial());
        }else{
            Destroy(gameObject);
        }
        
        
    }
    IEnumerator PlayTutorial(){
        yield return new WaitForSeconds(1);
        FtueJumpPanel.SetActive(true);
        FtueSlidePanel.SetActive(false);
        FtueKillMonsters.SetActive(false);
        FtueCollectPanel.SetActive(false);
        
        Time.timeScale = 0f;
        _gameEvents.ShowFTUE();
    }

    void GoToSlidePanel(){
        FtueJumpPanel.SetActive(false);
        FtueSlidePanel.SetActive(true);
    }
    void GoToKillMonstersPanel(){
        FtueSlidePanel.SetActive(false);
        FtueKillMonsters.SetActive(true);
    }
    void GoToCollectPanel(){
        FtueSlidePanel.SetActive(false);
        FtueCollectPanel.SetActive(true);
    }
    void DestroyFtue(){
        FtueJumpPanel.SetActive(false);
        FtueSlidePanel.SetActive(false);
        FtueKillMonsters.SetActive(false);
        FtueCollectPanel.SetActive(false);
        PlayerPrefs.SetInt("FTUE",1);
        Time.timeScale = 1f;
        _gameEvents.HideFTUE();
        Invoke("Destroy",2f);
    }

    void Destroy(){
        Destroy(gameObject);
    }
}

