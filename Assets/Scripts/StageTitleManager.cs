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
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponentInChildren<TMP_Text>();
        _text.text = StageTitle;
        _text.gameObject.SetActive(false);
        transform.DOShakeScale(2,0.5f,5).SetLoops(2).SetDelay(2f)
        .OnStart(() => {
            _text.gameObject.SetActive(true);
        })
        .OnComplete(() => {
            _text.gameObject.SetActive(false);
        }).SetUpdate(true);
       
    }

    
    
}
