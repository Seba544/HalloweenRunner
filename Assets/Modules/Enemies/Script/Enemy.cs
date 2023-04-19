using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public string Id { get; set; }
    public int HP { get; set; }
    public float Speed { get; set; }
    public bool IsDead => HP <=0;
    private IEnemyHealth _enemyHealthComponent;

    public Enemy(string id, int hp, float speed){
        Id = id;
        HP = hp;
        Speed = speed;
    }

    public void ReceiveDamage(int damagePoints){
        if(!IsDead)
            HP -= damagePoints;
        
    }
}
