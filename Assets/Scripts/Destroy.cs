using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Destroy : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    public float DestroyAfterSeconds;
    void Start()
    {
        _gameEvents.OnGameOver()
            .Subscribe(_ => StopAllCoroutines())
            .AddTo(this);
            
        StartCoroutine(DestroyItem());
    }

    private IEnumerator DestroyItem(){
        yield return new WaitForSeconds(DestroyAfterSeconds);
        Destroy(gameObject);
    }
}
