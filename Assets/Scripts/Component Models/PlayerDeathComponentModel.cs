using System.ComponentModel;
using System.Runtime.CompilerServices;
using Component_Models.Contracts;
using Events;
using Modules.Player.Scripts;

namespace Component_Models
{
    public class PlayerDeathComponentModel : IPlayerDeathComponentModel
    {
        private readonly IEventBus _eventBus;
        private readonly IPlayerRepository _playerRepository;
        private IPlayer _player;

        private bool _isDead;

        public bool IsDead
        {
            get => _isDead;
            set
            {
                if (value != _isDead)
                {
                    _isDead = value;
                    OnPropertyChanged();
                }
            } }

        public void PlayerDies()
        {
            _player.Death();
            GameOverEvent gameOverEvent = new GameOverEvent();
            _eventBus.Publish(gameOverEvent);
        }

        public PlayerDeathComponentModel(IEventBus eventBus, IPlayerRepository playerRepository)
        {
            _eventBus = eventBus;
            _playerRepository = playerRepository;
            _player = _playerRepository.GetPlayer();

            _player.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_player.IsDead))
            {
                IsDead = _player.IsDead;
            }
        }
        public void Dispose()
        {
            _player.PropertyChanged -= OnPropertyChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
