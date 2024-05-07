using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Modules.Player.Scripts
{
    public class Player : IPlayer
    {
        private bool _isGrounded;
        private bool _isSliding;
        private bool _isDead;
        private bool _isAbleToJump;
        private int _currentAmountOfJumps;

        public bool IsGrounded {get { return _isGrounded; }
            set
            {
                _isGrounded = value;
                if(value!=_isGrounded)
                    OnPropertyChanged(nameof(IsGrounded));
            }}

        public bool IsSliding
        {
            get
            {
                return _isSliding;
            }
            set
            {
                _isSliding = value;
                if(value!=_isSliding)
                    OnPropertyChanged(nameof(IsSliding));
            }
        }

        public bool IsDead
        {
            get
            {
                return _isDead;
            }
            set
            {
                _isDead = value;
                if(value!=_isDead)
                    OnPropertyChanged(nameof(IsDead));
            }
        }

        public bool IsAbleToJump
        {
            get
            {
                return _isAbleToJump;
            }
            set
            {
                _isAbleToJump = value;
                if(_isAbleToJump != value)
                    OnPropertyChanged();
            }
        }

        public void Jump()
        {
            _currentAmountOfJumps++;
            if (_currentAmountOfJumps == 2)
            {
                IsAbleToJump = false;
                _currentAmountOfJumps = 0;
            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}
