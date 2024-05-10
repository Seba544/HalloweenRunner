using System.ComponentModel;

namespace Modules.Player.Scripts
{
    public interface IPlayer : INotifyPropertyChanged
    {
        public bool IsGrounded { get; set; }
        public bool Jump();
    }
}
