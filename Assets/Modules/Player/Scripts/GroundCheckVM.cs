using System;
using System.ComponentModel;

namespace Modules.Player.Scripts
{
    public class GroundCheckVM : IGroundCheckVM
    {
        private readonly IGroundCheck _groundCheck;
        private readonly IPlayerRepository _playerRepository;
        private IPlayer _player;

        public GroundCheckVM(IGroundCheck groundCheck, IPlayerRepository playerRepository)
        {
            _groundCheck = groundCheck;
            _playerRepository = playerRepository;
            _player = _playerRepository.GetPlayer();
            _groundCheck.PropertyChanged += OnGroundCheckPropertyChanged;
        }

        private void OnGroundCheckPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_groundCheck.IsPlayerGrounded))
            {
                _player.IsGrounded = _groundCheck.IsPlayerGrounded;
                
            }
        }

        public void Dispose()
        {
            _groundCheck.PropertyChanged -= OnGroundCheckPropertyChanged;
        }
    }
}
