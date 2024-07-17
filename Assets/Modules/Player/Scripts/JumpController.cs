using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Events;

namespace Modules.Player.Scripts
{
    public class JumpController : IJumpController
    {
        private IEventBus _eventBus;
        private readonly IPlayerRepository _playerRepository;
        private IPlayer _player;
        private bool _isPlayerGrounded;
        private bool _isPlayerDead;
        private bool _isPlayerAbleToJump;

        public JumpController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
            _player = _playerRepository.GetPlayer();
            
        }
        
        public void Dispose()
        {
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Jump()
        {
            if(_player.Jump())
                DoJump?.Invoke();
        }

        public event Action DoJump = () => {};
    }
}
