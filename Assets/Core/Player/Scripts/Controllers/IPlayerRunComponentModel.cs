using System;
using System.ComponentModel;

namespace Component_Models.Contracts
{
    public interface IPlayerRunComponentModel : INotifyPropertyChanged,IDisposable
    {
        public bool IsDead { get; }
        public float CurrentSpeed { get; }

        void Run(float speed);
    }
}
