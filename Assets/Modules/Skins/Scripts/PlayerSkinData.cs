using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerSkinData
{
    public string CurrentSkin;
    public List<string> SkinsPurchased;

    public PlayerSkinData(string currentSkin, List<string> skinsPurchased){
        CurrentSkin = currentSkin;
        SkinsPurchased = skinsPurchased;
    }
}
