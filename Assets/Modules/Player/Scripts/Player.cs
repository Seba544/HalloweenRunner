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
                if (value)
                {
                    _currentAmountOfJumps = 0;
                }
                
                if (value != _isGrounded)
                {
                    _isGrounded = value;
                    OnPropertyChanged(nameof(IsGrounded));
                }
                    
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

        public bool Jump()
        {
            if (_isDead)
            {
                return false;
            }
            if (_isGrounded || _currentAmountOfJumps<2)
            {
                _currentAmountOfJumps++;
                _isAbleToJump = true;
                return true;
            }
            else
            {
                return false;
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}
