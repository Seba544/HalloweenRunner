using UnityEngine;

namespace Components
{
    public abstract class Monster : MonoBehaviour
    {
        protected string MonsterId;
        public MonsterType MonsterType;
        public abstract void Move();
        public abstract void Stop();
        public string GetMonsterId() => MonsterId;
    }

    public enum MonsterType
    {
        ZOMBIE,
        EVIL_BUG
    }
}
