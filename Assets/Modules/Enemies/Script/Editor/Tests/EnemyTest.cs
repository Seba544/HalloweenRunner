using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class EnemyTest
{
    private Enemy _enemy;

    [SetUp]
    public void setup(){
        _enemy = new Enemy("zombie",2,5f);
    }
    
    [Test]
    public void die_when_receive_damage_and_hp_is_less_or_equal_0(){

        _enemy.ReceiveDamage(2);

        Assert.IsTrue(_enemy.IsDead);
    }

    [Test]
    public void dont_die_when_receive_damage_and_hp_is_greater_than_0(){

        _enemy.ReceiveDamage(1);

        Assert.IsFalse(_enemy.IsDead);
    }
}
