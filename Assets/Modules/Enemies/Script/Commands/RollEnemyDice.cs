using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RollEnemyDice : ICommandWithResult<GameObject>
{
    private Dice _enemyDice;
    private int _rollResult;
    private List<EnemyInitializer> _enemies;
    public RollEnemyDice(Dice enemyDice,int rollResult,List<EnemyInitializer> enemies){
        _enemyDice = enemyDice;
        _rollResult = rollResult;
        _enemies = enemies;
    }
    public GameObject Execute()
    {
        var enemySelected = _enemyDice.Faces[_rollResult-1];
        var enemyPrefab = _enemies.Where(enemy => enemy.Data.EnemyID==enemySelected).FirstOrDefault();
        return enemyPrefab.gameObject;
    }
}
