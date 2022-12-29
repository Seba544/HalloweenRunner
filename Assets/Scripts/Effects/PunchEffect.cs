using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PunchEffect : MonoBehaviour
{
    public int AmountOfLoops;
    public float Duration;
    public Ease EaseType;

    
    void OnEnable()
    {
        DoEffect();
    }

    

    void DoEffect(){
        transform.DOPunchScale(new Vector3(0.3f,0.3f,0.3f),Duration,2).SetLoops(AmountOfLoops).SetEase(EaseType);
    }
}
