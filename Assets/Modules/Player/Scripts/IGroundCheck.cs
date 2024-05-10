using System.ComponentModel;

namespace Modules.Player.Scripts
{
    public interface IGroundCheck : INotifyPropertyChanged
    {
        public bool IsPlayerGrounded { get; set; }
    }
}
