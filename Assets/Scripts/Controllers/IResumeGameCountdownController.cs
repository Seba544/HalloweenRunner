using System;
using System.ComponentModel;
using Components.Contracts;
using Events;

namespace Contracts
{
    public interface IResumeGameCountdownController : IDisposable
    {
        event Action InitCountdown;
    }

}
