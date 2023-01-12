using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Pumpking : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    Vector3 originalScale;
    private Transform MoveToTarget;
    List<IMovementStrategy> Strategies;
    private AudioSource _audio;
    public AudioClip CollectAudioClip;
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        Strategies = new List<IMovementStrategy>{
            new OnAirMovement(),
            new OnGroundMovement()
        };
        MoveToTarget = GameObject.FindGameObjectWithTag("PumpkingScore").transform;
        originalScale = transform.localScale;

        
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        DefineMovement();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            _audio.PlayOneShot(CollectAudioClip);
            _gameEvents.CollectPumpking();
            
            transform.DOMove(MoveToTarget.position,0.3f);
            transform.DOScale(new Vector3(0.01f,0.01f,0.01f),0.3f);
            Destroy(gameObject,0.3f);
        }
        
    }

    void DefineMovement(){
        var strategy = Strategies[UnityEngine.Random.Range(0,Strategies.Count)];
        strategy.Execute(transform);
    }
    void OnDestroy()
    {
        DOTween.KillAll();
    }
    
}

interface IMovementStrategy{
    void Execute(Transform pumpking);
}

class OnGroundMovement :  IMovementStrategy{
    public void Execute(Transform pumpking)
    {
        //Debug.Log("Se queda en el suelo");
    }
}
class OnAirMovement :  IMovementStrategy{

    public void Execute(Transform pumpking)
    {
        float offsetY = pumpking.position.y + 5f;
        pumpking.position = new Vector3(pumpking.position.x, offsetY, pumpking.position.z);
    }
}
