using System;
using System.ComponentModel;
using Components.Contracts;
using Events;

namespace Component_Models.Contracts
{
    public interface IResumeGameCountdownComponentModel : IDisposable
    {
        event Action InitCountdown;
    }
}