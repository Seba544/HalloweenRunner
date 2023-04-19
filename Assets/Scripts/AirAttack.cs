using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class AirAttack : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    private EnemyConfig _enemyData;
    public float DistanceFromGround;
    private Rigidbody2D _rgbd;
    bool isMoving;
    private Enemy _enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        _enemy = GetComponent<EnemyInitializer>()._enemy;
        isMoving = true;
        _rgbd = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(transform.position.x,transform.position.y+DistanceFromGround,0);
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
    void FixedUpdate()
    {
        if(Time.timeScale==0 || !isMoving){
            _rgbd.velocity = Vector2.zero;
            return;
        }
        _rgbd.velocity = new Vector2(_enemy.Speed * -1, _rgbd.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            _gameEvents.GameOver();  
        }
    }
}
