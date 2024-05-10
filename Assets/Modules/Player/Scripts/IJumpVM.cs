using System;
using System.ComponentModel;

namespace Modules.Player.Scripts
{
    public interface IJumpVM : INotifyPropertyChanged,IDisposable
    {
        event Action DoJump;
    }
}
