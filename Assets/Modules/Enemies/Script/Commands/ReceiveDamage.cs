using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveDamage : ICommand
{
    IEnemyHealth _enemyHealth;
    int _damageReceived;
    EnemyConfig _enemyConfig;
    public ReceiveDamage(EnemyConfig enemyConfig,IEnemyHealth enemyHealth, int damageReceived){
        _enemyConfig = enemyConfig;
        _enemyHealth = enemyHealth;
        _damageReceived = damageReceived;
    }
    public void Execute()
    {
        int currentHP = _enemyHealth.GetCurrentHP();
        currentHP -= _damageReceived;
        if(currentHP<=0){
            _enemyHealth.DoExplotionEffect();
            _enemyHealth.DestroyObject();
            
        }
    }
}
