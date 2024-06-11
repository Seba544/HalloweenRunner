using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using System.Linq;
using Components;
using Random = UnityEngine.Random;

public class ItemSpawner : MonoBehaviour
{
    public Dice Dice;
    [SerializeField] GameEvent _gameEvents;
    public List<EnemyInitializer> Enemies;
    public List<Monster> Monsters;
    public GameObject Pumpkin;
    Coroutine _spawnCoroutine = null;
    public float MinSpawnTime;
    public float MaxSpawnTime;
    const int ProbabilityOfOccurrencePumpkin = 1;

    public List<GameObject> Candies;
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
                StartCoroutine(FinishLevel());
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
            if(Random.Range(1,11)<=ProbabilityOfOccurrencePumpkin){
                Instantiate(Candies[Random.Range(0,Candies.Count)], transform.position, Quaternion.identity);
                Debug.Log("Candy spawned");
            }else{
                //var rollEnemyDice = new RollEnemyDice(Dice,Random.Range(1,11),Enemies);
                //var enemyPrefab = rollEnemyDice.Execute();
                Instantiate(Monsters.First(), transform.position, Quaternion.identity);
            }
            
        }

    }

    void StopSpawningEnemies()
    {
        if(_spawnCoroutine!=null)
            StopCoroutine(_spawnCoroutine);
       
    }
    IEnumerator FinishLevel(){
        yield return new WaitForSeconds(4);
        _gameEvents.EndOfLevel();
    }

    
    
}
    [Serializable]
    public class Dice{
        public List<string> Faces = new List<string>();
    }
