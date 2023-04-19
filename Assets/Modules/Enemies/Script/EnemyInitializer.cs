using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInitializer : MonoBehaviour
{
    public EnemyConfig Data;
    public Enemy _enemy;

    void Awake()
    {
        _enemy = new Enemy(Data.EnemyID,Data.HP,Data.Speed);
    }
}

