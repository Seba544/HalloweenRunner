using System;
using System.ComponentModel;

namespace Modules.Player.Scripts
{
    public interface IJumpComponentModel : INotifyPropertyChanged,IDisposable
    {
        event Action DoJump;
    }
}
