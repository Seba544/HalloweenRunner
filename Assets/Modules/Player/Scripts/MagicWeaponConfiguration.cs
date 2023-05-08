using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Magic Weapon", menuName = "ScriptableObjects/Magic Weapon", order = 1)]
public class MagicWeaponConfiguration : ScriptableObject
{
    public string ID;
    public int Price;
    public int DamagePoints;
    public int BuyAmount;
    public float ReloadTime;
    public Sprite Icon;
}
