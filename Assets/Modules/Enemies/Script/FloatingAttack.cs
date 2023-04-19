using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloatingAttack : EnemyInitializer
{
    [SerializeField] GameEvent _gameEvents;
    private Enemy _enemyData;
    Vector2 _destinationUp;
    Vector2 _destinationDown;
    Vector2 _currentDestination;
    public float FloatingOffsetY;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _enemyData = GetComponent<Enemy>();
       
       _destinationUp = new Vector2(transform.position.x,transform.position.y+FloatingOffsetY);
       _destinationDown = transform.position;
        SetInitialPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(_destinationUp,transform.position)<=0.1f){
            
            _currentDestination = _destinationDown;
        }
        if(Vector2.Distance(_destinationDown,transform.position)<=0.1f){
            _currentDestination = _destinationUp;
        }
        transform.position = Vector2.MoveTowards(transform.position, _currentDestination,Time.deltaTime*_enemy.Speed);
    }
    void SetInitialPosition(){
        if(Random.Range(0,2)==0){
            transform.position = _destinationDown;
            _currentDestination = _destinationUp;
        }else{
            transform.position = _destinationUp;
            _currentDestination = _destinationDown;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            _gameEvents.GameOver();
        }
    }
}
