using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class OnClickAnimation : MonoBehaviour
{
    private Button _button;
    Tweener tween;
    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(PlayAnimation);
    }

    void PlayAnimation(){
        if(tween == null)
            tween = transform.DOPunchScale(new Vector3(0.5f,0.5f,0.5f),0.5f,5);
        if(!tween.IsPlaying())
            tween = transform.DOPunchScale(new Vector3(0.5f,0.5f,0.5f),0.5f,5);
    }
}
