using System.ComponentModel;
using System.Runtime.CompilerServices;
using Component_Models.Contracts;
using Modules.Player.Scripts;

namespace Component_Models
{
    public class PlayerRunComponentModel : IPlayerRunComponentModel
    {
        private readonly IPlayerRepository _playerRepository;
        private bool _isDead;
        private float _currentSpeed;
        private IPlayer _player;

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
            }
        }

        public float CurrentSpeed
        {
            get => _currentSpeed;
            set
            {
                if (value != _currentSpeed)
                {
                    _currentSpeed = value;
                    OnPropertyChanged();
                }
            }
        }

        public void Run(float speed)
        {
            _player.Run(speed);
        }

        public PlayerRunComponentModel(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
            _player = playerRepository.GetPlayer();

            _player.PropertyChanged += OnPlayerPropertyChanged;
        }

        private void OnPlayerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_player.IsDead))
            {
                IsDead = _player.IsDead;
            }

            if (e.PropertyName == nameof(_player.CurrentSpeed))
            {
                CurrentSpeed = _player.CurrentSpeed;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void Dispose()
        {
            _player.PropertyChanged -= OnPlayerPropertyChanged;
        }
        
    }
}
