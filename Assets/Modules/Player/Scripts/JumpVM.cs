using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Modules.Player.Scripts
{
    public class JumpVM : IJumpVM,IDisposable
    {
        private readonly IJump _component;
        private readonly IPlayerRepository _playerRepository;
        private IPlayer _player;

        private bool _isPlayerSliding;
        private bool _isPlayerGrounded;
        private bool _isPlayerDead;

        public bool IsPlayerSliding
        {
            get
            {
                return _isPlayerSliding;
            }
            set
            {
                _isPlayerSliding = value;
                if (_isPlayerSliding != value)
                    OnPropertyChanged(nameof(IsPlayerSliding));
            }
        }

        public bool IsPlayerGrounded
        {
            get
            {
                return _isPlayerGrounded;
            }
            set
            {
                _isPlayerGrounded = value;
                if(_isPlayerGrounded!=value)
                    OnPropertyChanged(nameof(IsPlayerGrounded));
            }
        }

        public bool IsPlayerDead
        {
            get
            {
                return _isPlayerDead;
            }
            set
            {
                _isPlayerDead = value;
                if(_isPlayerDead!=value)
                    OnPropertyChanged(nameof(IsPlayerDead));
            }
        }

        public JumpVM(IJump component,IPlayerRepository playerRepository)
        {
            _component = component;
            _playerRepository = playerRepository;
            _player = _playerRepository.GetPlayer();

            _player.PropertyChanged += OnPlayerPropertyChanged;
            _component.JumpAction += OnJumpAction;
        }

        private void OnJumpAction()
        {
            _player.Jump();
        }

        private void OnPlayerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_player.IsGrounded))
            {
                IsPlayerGrounded = _player.IsGrounded;
            }

            if (e.PropertyName == nameof(_player.IsSliding))
            {
                IsPlayerSliding = _player.IsSliding;
            }

            if (e.PropertyName == nameof(_player.IsDead))
            {
                IsPlayerDead = _player.IsDead;
            }
        }

        public void Dispose()
        {
            _player.PropertyChanged -= OnPlayerPropertyChanged;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
