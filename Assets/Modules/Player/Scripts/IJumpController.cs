using System;
using System.ComponentModel;

namespace Modules.Player.Scripts
{
    public interface IJumpController : INotifyPropertyChanged,IDisposable
    {
        void Jump();
        event Action DoJump;
    }
}
