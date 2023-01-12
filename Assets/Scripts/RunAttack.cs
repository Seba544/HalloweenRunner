using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class RunAttack : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    private Rigidbody2D _rgbd;
    public float Speed;

    bool isMoving;
    private Animator _animator;
    
    void Start()
    {
        isMoving = true;
        _rgbd = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _gameEvents.OnGameOver()
            .Subscribe(_ => {
                isMoving = false;
            })
            .AddTo(this);
        _gameEvents.OnRevive()
            .Subscribe(_ => {
                isMoving = true;
            })
            .AddTo(this);
    }
    void LateUpdate()
    {

        if(isMoving){
            _animator.SetBool("isRunning",true);
        }else{
            _animator.SetBool("isRunning",false);
        }

        if(Time.timeScale==0 || !isMoving){
            _rgbd.velocity = Vector2.zero;
            return;
        }
             

        _rgbd.velocity = new Vector2(Speed * -1, _rgbd.velocity.y);
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            _gameEvents.GameOver();
        }
    }
}
