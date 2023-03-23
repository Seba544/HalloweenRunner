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
        transform.DOPunchScale(new Vector3(0.1f,0.1f,0.1f),Duration,1).SetLoops(AmountOfLoops).SetEase(EaseType).SetUpdate(true);
    }
    
}
