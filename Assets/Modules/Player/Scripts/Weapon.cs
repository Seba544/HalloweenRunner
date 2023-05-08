using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public string Id { get; set; }
    public int Ammunition { get; set; }
    public int DamagePoints { get; set; }
    public int Price { get; set; }
    public float ReloadTime { get; set; }
    public bool IsOutOfAmmo => Ammunition==0;
    public WeaponState WeaponState;
    
    public Weapon(string id,int price, int ammunition, int damagePoints,float reloadTime,WeaponState state){
        Id = id;
        Price = price;
        Ammunition = ammunition;
        DamagePoints = damagePoints;
        ReloadTime = reloadTime;
        WeaponState = state;
    }

    public void Shoot()
    {
        if(WeaponState==WeaponState.RELOADING || WeaponState== WeaponState.NO_AMMO)
            return;
        
        Ammunition--;
        if(Ammunition<=0){
            Ammunition=0;
            WeaponState = WeaponState.NO_AMMO;
        }
    }

    public bool IsTheReloadDone(float elapsedTime)
    {
        return elapsedTime>=ReloadTime;
    }

    public bool CanAffordBuy(int amountOfPumpkins)
    {
        return amountOfPumpkins>=Price;
    }
}

public enum WeaponState{
    NO_AMMO,
    RELOADING,
    READY

}
