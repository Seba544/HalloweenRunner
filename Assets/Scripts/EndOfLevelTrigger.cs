using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevelTrigger : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            _gameEvents.EndOfLevel();
        }
    }
}
