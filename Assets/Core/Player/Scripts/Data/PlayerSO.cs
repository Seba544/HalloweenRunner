using UnityEngine;

namespace Core.Player.Scripts.Data
{
    [CreateAssetMenu(fileName = "Player Data", menuName = "ScriptableObjects/Player Data", order = 1)]
    public class PlayerSO : ScriptableObject
    {
        public float RunSpeed;
        public float WalkSpeed;
        public float JumpForce;
    }
}
