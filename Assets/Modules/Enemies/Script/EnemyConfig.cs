using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemies/Enemy", order = 1)]
public class EnemyConfig : ScriptableObject
{
    public string EnemyID;
    public float Speed;
    public int HP;
}
