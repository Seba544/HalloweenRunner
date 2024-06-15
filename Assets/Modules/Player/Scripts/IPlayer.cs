using System.ComponentModel;

namespace Modules.Player.Scripts
{
    public interface IPlayer : INotifyPropertyChanged
    {
        public bool IsGrounded { get; }
        public bool IsDead { get; }
        public float CurrentSpeed { get; }
        void Run(float speed);
        public bool Jump();
        void Death();
        void SetGrounded(bool isGrounded);
    }
}
