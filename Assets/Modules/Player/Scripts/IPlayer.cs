using System.ComponentModel;

namespace Modules.Player.Scripts
{
    public interface IPlayer : INotifyPropertyChanged
    {
        public bool IsGrounded { get; set; }
        public bool IsSliding { get; set; }
        public bool IsDead { get; set; }
        public bool IsAbleToJump { get; set; }
        public void Jump();
    }
}
