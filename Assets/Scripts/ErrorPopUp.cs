using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class ErrorPopUp : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    public GameObject PopUp;
    public Button _button;
    // Start is called before the first frame update
    void Start()
    {
        Hide();
        _button.onClick.AddListener(GoToHome);
        _gameEvents.OnShowError()
            .Subscribe(_ =>{
                Show();
                StartCoroutine(SafeExit());
            } )
            .AddTo(this);
            
    }

    void Show() => PopUp.SetActive(true);
    void Hide() => PopUp.SetActive(false);
    void GoToHome(){
        _gameEvents.LoadScene.OnNext("Home");
    }
    IEnumerator SafeExit(){
        yield return new WaitForSeconds(5);
        _gameEvents.LoadScene.OnNext("LevelSelection");
    }
}
