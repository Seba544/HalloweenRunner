using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public string Id { get; set; }
    public int Ammunition { get; set; }
    public int DamagePoints { get; set; }
    public bool IsOutOfAmmo => Ammunition==0;
    public Weapon(string id, int ammunition, int damagePoints){
        Id = id;
        Ammunition = ammunition;
        DamagePoints = damagePoints;
    }

    public void Shoot()
    {
        if(!IsOutOfAmmo)
            Ammunition--;
    }
}
