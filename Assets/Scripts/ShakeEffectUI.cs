using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShakeEffectUI : MonoBehaviour
{
    

    void OnEnable()
    {
        Debug.Log("Asdasd");
        transform.DOShakeRotation(2,30f).SetLoops(5);
    }
    
}
