using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrap : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    private EnemyConfig _enemyData;
    void Start()
    {
        _enemyData = GetComponent<Enemy>().Data;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            _gameEvents.GameOver();
        }
    }
}
