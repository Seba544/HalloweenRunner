using System;
using System.ComponentModel;

namespace Component_Models.Contracts
{
    public interface IMonsterComponentModel : INotifyPropertyChanged, IDisposable
    {
        public float CurrentSpeed { get; set; }
        void Move();
        void Stop();
        event Action<float,float,float> RelocateToSpawnPoint;
        string GetMonsterId();
    }
}
