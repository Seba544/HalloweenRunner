using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class WeaponTest
{
    private Weapon _weapon;

    [SetUp]
    public void setup(){
        _weapon = new Weapon("magic_projectile",10,1);
    }

    [Test]
    public void decrease_ammunition_when_shoot(){

        _weapon.Shoot();

        Assert.AreEqual(_weapon.Ammunition,9);

    }
    [Test]
    public void return_out_of_ammo_true_if_ammunition_is_0(){

        _weapon.Shoot();
        _weapon.Shoot();
        _weapon.Shoot();
        _weapon.Shoot();
        _weapon.Shoot();
        _weapon.Shoot();
        _weapon.Shoot();
        _weapon.Shoot();
        _weapon.Shoot();
        _weapon.Shoot();

        Assert.IsTrue(_weapon.IsOutOfAmmo);
    }

    [Test]
    public void return_out_of_ammo_false_if_ammunition_is_greater_than_0(){

        _weapon.Shoot();
        _weapon.Shoot();
        _weapon.Shoot();
        _weapon.Shoot();
        _weapon.Shoot();
        _weapon.Shoot();
        _weapon.Shoot();
        _weapon.Shoot();
        _weapon.Shoot();
        

        Assert.IsFalse(_weapon.IsOutOfAmmo);
    }

    [Test]
    public void do_not_decrease_ammunition_if_weapon_is_out_of_ammo(){
        _weapon.Ammunition = 0;

        _weapon.Shoot();

        Assert.AreEqual(0,_weapon.Ammunition);
    }
}
