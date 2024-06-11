using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Component_Models.Contracts;
using Events;
using Models;

namespace Component_Models
{
    public class MonsterComponentModel : IMonsterComponentModel
    {
        private readonly IEventBus _eventBus;
        private float _currentSpeed;

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

        public void Init()
        {
            _monster.Move();
        }

        private IMonster _monster;

        public MonsterComponentModel(IEventBus eventBus,float monsterSpeed)
        {
            _eventBus = eventBus;
            _eventBus.Subscribe<PauseGameEvent>(OnPauseGameEvent);
            _eventBus.Subscribe<ResumeGameEvent>(OnResumeGame);
            _eventBus.Subscribe<GameOverEvent>(OnGameOver);
            _monster = new Monster(monsterSpeed);
            _monster.PropertyChanged += OnPropertyChanged;
        }

        private void OnGameOver(GameOverEvent _)
        {
            _monster.Stop();
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_monster.CurrentSpeed))
            {
                CurrentSpeed = _monster.CurrentSpeed;
            }
        }

        private void OnResumeGame(ResumeGameEvent obj)
        {
            _monster.Move();
        }

        private void OnPauseGameEvent(PauseGameEvent _)
        {
            _monster.Stop();
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<PauseGameEvent>(OnPauseGameEvent);
            _eventBus.Unsubscribe<ResumeGameEvent>(OnResumeGame);
            _eventBus.Unsubscribe<GameOverEvent>(OnGameOver);
            _monster.PropertyChanged -= OnPropertyChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
