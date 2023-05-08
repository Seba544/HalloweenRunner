using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class WeaponTest
{
    private Weapon _weapon;

    [SetUp]
    public void setup(){
        _weapon = new Weapon("magic_projectile",5,10,1,3,WeaponState.READY);
    }

    [Test]
    public void shoot_if_weapon_state_is_ready(){
        _weapon.Ammunition=10;
        _weapon.WeaponState = WeaponState.READY;

        _weapon.Shoot();
        _weapon.Shoot();
        _weapon.Shoot();

        Assert.AreEqual(7,_weapon.Ammunition);

    }
    [Test]
    public void do_not_shoot_if_weapon_state_is_no_ammo(){
        _weapon.Ammunition=0;
        _weapon.WeaponState = WeaponState.NO_AMMO;

        _weapon.Shoot();
        _weapon.Shoot();
        _weapon.Shoot();
        

        Assert.AreEqual(0,_weapon.Ammunition);
    }

    [Test]
    public void do_not_shoot_if_weapon_state_is_reloading(){
        _weapon.Ammunition = 10;
        _weapon.WeaponState = WeaponState.RELOADING;

        _weapon.Shoot();

        Assert.AreEqual(10,_weapon.Ammunition);
    }
    [Test]
    public void return_can_afford_buy_true_if_amount_of_pumpkins_is_greater_or_equal_than_weapon_price(){
        int amountOfPumpkins = 10;
        _weapon.Price = 5;

        bool result = _weapon.CanAffordBuy(amountOfPumpkins);

        Assert.IsTrue(result);
    }

    [Test]
    public void return_can_afford_buy_false_if_amount_of_pumpkins_is_less_than_weapon_price(){
        int amountOfPumpkins = 4;
        _weapon.Price = 5;

        bool result = _weapon.CanAffordBuy(amountOfPumpkins);

        Assert.IsFalse(result);
    }
    
}
