using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Modules.Player.Scripts
{
    public class JumpVM : IJumpVM
    {
        private readonly IJump _component;
        private readonly IPlayerRepository _playerRepository;
        private IPlayer _player;
        private bool _isPlayerGrounded;
        private bool _isPlayerSliding;
        private bool _isPlayerDead;
        private bool _isPlayerAbleToJump;
        
        public JumpVM(IJump component,IPlayerRepository playerRepository)
        {
            _component = component;
            _playerRepository = playerRepository;
            _player = _playerRepository.GetPlayer();
            
            _component.JumpInputAction += OnJumpInputAction;
        }

        private void OnJumpInputAction()
        {
            if(_player.Jump())
                DoJump?.Invoke();
        }
        

        public void Dispose()
        {
            _component.JumpInputAction -= OnJumpInputAction;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsSliding
        {
            get
            {
                return _isPlayerSliding;
            }
            set
            {
                if (value != _isPlayerSliding)
                {
                    _isPlayerSliding = value;
                    OnPropertyChanged(nameof(IsSliding));
                }
            }
        }

        public event Action DoJump = () => {};
    }
}
