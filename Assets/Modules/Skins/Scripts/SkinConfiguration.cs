using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skin Configuration", menuName = "ScriptableObjects/Player/Skin Configuration", order = 1)]
public class SkinConfiguration : ScriptableObject
{
    public string SkinID;
    public int SkinPrice;
    public GameObject Player;
}
