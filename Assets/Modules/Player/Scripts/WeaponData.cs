using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class WeaponData
{
    public string Id;
    public int Ammunition;
    public int DamagePoints;
    public int Price;
    public float ReloadTime;

    public WeaponData(Weapon weapon){
        Id=weapon.Id;
        Ammunition=weapon.Ammunition;
        DamagePoints = weapon.DamagePoints;
        Price=weapon.Price;
        ReloadTime=weapon.ReloadTime;
    }
}
