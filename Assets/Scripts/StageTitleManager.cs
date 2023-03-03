using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class StageTitleManager : MonoBehaviour
{
    public string StageTitle;
    public float WaitTime;
    private TMP_Text _text;
    bool isTitleOnScreen;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponentInChildren<TMP_Text>();
        _text.text = StageTitle;
        _text.gameObject.SetActive(false);
        StartCoroutine(VerifyTitleOnScreen());
        transform.DOShakeScale(2,0.5f,5).SetLoops(2).SetDelay(2f)
        .OnStart(() => {
            _text.gameObject.SetActive(true);
            isTitleOnScreen = true;
        })
        .OnComplete(() => {
            _text.gameObject.SetActive(false);
            isTitleOnScreen=false;
        }).SetUpdate(true);
       
    }
    IEnumerator VerifyTitleOnScreen(){
        yield return new WaitForSeconds(6);
        if(isTitleOnScreen)
            _text.gameObject.SetActive(false);
    }

    
    
}
