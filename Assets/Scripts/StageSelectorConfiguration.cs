using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stage Selector Config", menuName = "ScriptableObjects/Stage Selector Config", order = 1)]
public class StageSelectorConfiguration : ScriptableObject
{
    public string WorldName;
    public int RequiredPumpkingsToUnlock;
    public bool IsInDevelopment;
    public bool IsUnlockable;
    public Sprite Frame;
}
