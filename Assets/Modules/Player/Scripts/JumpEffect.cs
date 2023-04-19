using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEffect : MonoBehaviour
{
    [SerializeField] Animation _anim;
    [SerializeField] AnimationClip _jumpEffectClip;
    // Start is called before the first frame update
    void Start()
    {
        _anim.AddClip(_jumpEffectClip,"JumpE");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("Salta");
            
            _anim.Play("JumpE");
        }
    }
}
