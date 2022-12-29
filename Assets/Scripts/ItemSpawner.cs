using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    public List<GameObject> Items;
    Coroutine _spawnCoroutine = null;
    public GameObject EndOfLevelPortal;
    public float MinSpawnTime;
    public float MaxSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        _spawnCoroutine = StartCoroutine(Spawn());
        _gameEvents.OnGameOver()
            .Subscribe(_ =>{
                StopSpawningEnemies();
            } )
            .AddTo(this);
        _gameEvents.EndWave()
             .Subscribe(_ =>{
                StopSpawningEnemies();
                CreateEndOfLevel();
             })
             .AddTo(this);
        _gameEvents.OnRevive()
            .Subscribe(_ => {
                _spawnCoroutine = StartCoroutine(Spawn());
            })
            .AddTo(this);
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(MinSpawnTime,MaxSpawnTime));
            Instantiate(Items[Random.Range(0, Items.Count)], transform.position, Quaternion.identity);
        }

    }

    void StopSpawningEnemies()
    {
        if(_spawnCoroutine!=null)
            StopCoroutine(_spawnCoroutine);
       
    }
    void CreateEndOfLevel(){
        Instantiate(EndOfLevelPortal,transform.position,Quaternion.identity);
    }
}
