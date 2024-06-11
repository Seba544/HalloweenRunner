using UnityEngine;

namespace Components
{
    public abstract class Monster : MonoBehaviour
    {
        public abstract void Move();
        public abstract void Stop();
    }
}
