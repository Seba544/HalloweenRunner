using System;
using System.ComponentModel;

namespace Core.Monsters.Scripts.Component_Models
{
    public interface IMonsterComponentModel : INotifyPropertyChanged, IDisposable
    {
        public float CurrentSpeed { get; set; }
        void Move();
        void Stop();
        event Action<float,float,float> RelocateToSpawnPoint;
        string GetMonsterId();
        void CollideWithPlayer();
    }
}
