using System;
using System.ComponentModel;

namespace Component_Models.Contracts
{
    public interface IPlayerRunController : INotifyPropertyChanged,IDisposable
    {
        public bool IsDead { get; }
        public float CurrentSpeed { get; }

        void Run();
    }
}
