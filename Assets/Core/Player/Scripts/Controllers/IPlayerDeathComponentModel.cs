using System;
using System.ComponentModel;

namespace Component_Models.Contracts
{
    public interface IPlayerDeathComponentModel : INotifyPropertyChanged, IDisposable
    {
        public bool IsDead { get; }
    }
}
