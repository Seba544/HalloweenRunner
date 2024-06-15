using System.Collections.Generic;
using UnityEngine;

namespace Configuration
{
    [CreateAssetMenu(fileName = "Dice", menuName = "ScriptableObjects/Dices/Dice", order = 1)]
    public class DiceConfiguration : ScriptableObject
    {
        public List<DiceFace> Faces;
    }

    public enum DiceFace
    {
        MONSTER,
        OBSTACLE,
        PLATFORM,
        CANDY
    }
}
