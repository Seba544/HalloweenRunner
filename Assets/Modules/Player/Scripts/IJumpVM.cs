using System.ComponentModel;

namespace Modules.Player.Scripts
{
    public interface IJumpVM : INotifyPropertyChanged
    {
        public bool IsPlayerSliding { get; set; }
        public bool IsPlayerGrounded { get; set; }
        public bool IsPlayerDead { get; set; }
    }
}
