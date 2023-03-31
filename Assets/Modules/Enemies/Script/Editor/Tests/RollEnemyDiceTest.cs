using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class RollEnemyDiceTest
{
    public GameObject _gameObject;
    ICommandWithResult<GameObject> _cmd;


    [SetUp]
    public void Setup(){
        
        
        _gameObject = new GameObject();
        _gameObject.AddComponent<ItemSpawner>();

        var itemSpawner = _gameObject.GetComponent<ItemSpawner>();
        itemSpawner.Dice = new Dice();
        itemSpawner.Dice.Faces.Add("evilBug");
        itemSpawner.Dice.Faces.Add("evilBug");
        itemSpawner.Dice.Faces.Add("evilBug");
        itemSpawner.Dice.Faces.Add("evilBug");
        itemSpawner.Dice.Faces.Add("zombie");
        itemSpawner.Dice.Faces.Add("zombie");
        itemSpawner.Dice.Faces.Add("zombie");
        itemSpawner.Dice.Faces.Add("zombie");
        itemSpawner.Dice.Faces.Add("zombie");
        itemSpawner.Dice.Faces.Add("zombie");

        var itemSpawnerComponent = _gameObject.GetComponent<ItemSpawner>();
        
    }


    [Test]
    public void Spawn_A_Zombie_If_Roll_Result_Equals_5_And_Die_Face_5_Is_Zombie(){
        var itemSpawnerComponent = _gameObject.GetComponent<ItemSpawner>();

        var zombie = new GameObject();
        zombie.AddComponent<Enemy>();
        var zombieScript = zombie.GetComponent<Enemy>();
        zombieScript.Data = ScriptableObject.CreateInstance<EnemyConfig>();
        zombieScript.Data.EnemyID = "zombie";

        var evilBug = new GameObject();
        evilBug.AddComponent<Enemy>();
        var evilBugScript = evilBug.GetComponent<Enemy>();
        evilBugScript.Data = ScriptableObject.CreateInstance<EnemyConfig>();
        evilBugScript.Data.EnemyID = "evilBug";
        
        itemSpawnerComponent.Enemies = new List<Enemy>();
        itemSpawnerComponent.Enemies.Add(zombie.GetComponent<Enemy>());
        itemSpawnerComponent.Enemies.Add(evilBug.GetComponent<Enemy>());

        int rollResult = 5;
        _cmd = new RollEnemyDice(itemSpawnerComponent.Dice,rollResult,itemSpawnerComponent.Enemies);



        var enemy = _cmd.Execute();

        Assert.AreEqual(enemy.GetComponent<Enemy>().Data.EnemyID,"zombie");
    }
}
