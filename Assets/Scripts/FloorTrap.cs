using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrap : EnemyInitializer
{
    [SerializeField] GameEvent _gameEvents;
    void Start()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            _gameEvents.GameOver();
        }
    }
}
