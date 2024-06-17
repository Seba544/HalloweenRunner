using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using System.Linq;
using Builder.Controllers;
using Components;
using Configuration;
using Controllers;
using Events;
using Strategies;
using Random = UnityEngine.Random;

public class ItemSpawner : MonoBehaviour
{
    public DiceConfiguration Dice;
    [SerializeField] GameEvent _gameEvents;
    public List<Monster> Monsters;
    public List<Candy> Candies;
    Coroutine _spawnCoroutine = null;
    public float MinSpawnTime;
    public float MaxSpawnTime;
    public MonsterObjectPool MonsterObjectPool;
    public CandyObjectPool CandyObjectPool;
    private IEventBus _eventBus;

    private IObjectSpawnerController _controller;


    private void Awake()
    {
        var builder = new ObjectSpawnerControllerBuilder();
        builder.Create();
        _controller = builder.GetObjectSpawnerController();
    }

    void Start()
    {
        
        _spawnCoroutine = StartCoroutine(SpawnV2());
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
                _spawnCoroutine = StartCoroutine(SpawnV2());
            })
            .AddTo(this);
    }

    IEnumerator SpawnV2()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(MinSpawnTime,MaxSpawnTime));
            var face = RollDice();
            
            switch (face)
            {
                case DiceFace.MONSTER:
                    Monster monsterSelected = Monsters[Random.Range(0,Monsters.Count)];
                    Monster monsterGO = MonsterObjectPool.GetObject(monsterSelected.MonsterType);
                    _controller.RelocateObjectSpawnPosition(monsterGO.GetMonsterId(),transform.position.x,transform.position.y,0);
                    break;
                case DiceFace.CANDY:
                    var candySelected = Candies[Random.Range(0, Candies.Count)];
                    var candyGO = CandyObjectPool.GetObject(candySelected.CandyType);
                    _controller.RelocateObjectSpawnPosition(candyGO.GetCandyId(),transform.position.x,transform.position.y,0);
                    break;
            }
        }
    }

    private DiceFace RollDice()
    {
        int rollDiceResult = Random.Range(0, Dice.Faces.Count);
        DiceFace face = Dice.Faces[rollDiceResult];
        return face;
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

public record ObjectSpawnPosition
{
    public float PosX;
    public float PosY;
    public float PosZ;

    public ObjectSpawnPosition(float posX, float posY, float posZ)
    {
        PosX = posX;
        PosY = posY;
        PosZ = posZ;
    }
}


