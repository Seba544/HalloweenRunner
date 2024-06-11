using System;
using System.ComponentModel;

namespace Component_Models.Contracts
{
    public interface IMonsterComponentModel : INotifyPropertyChanged, IDisposable
    {
        public float CurrentSpeed { get; set; }
        void Init();
    }
}
