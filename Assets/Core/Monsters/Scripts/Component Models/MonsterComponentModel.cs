using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Events;
using Models;

namespace Core.Monsters.Scripts.Component_Models
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

        public void Move()
        {
            _monster.Move();
        }

        public void Stop()
        {
            _monster.Stop();
        }

        public event Action<float,float,float> RelocateToSpawnPoint;
        public string GetMonsterId() => _monster.MonsterId;
        public void CollideWithPlayer()
        {
            GameOverEvent gameOverEvent = new GameOverEvent();
            _eventBus.Publish(gameOverEvent);
        }

        private IMonster _monster;

        public MonsterComponentModel(IEventBus eventBus,float monsterSpeed)
        {
            _eventBus = eventBus;
            _eventBus.Subscribe<PauseGameEvent>(OnPauseGameEvent);
            _eventBus.Subscribe<ResumeGameEvent>(OnResumeGame);
            _eventBus.Subscribe<GameOverEvent>(OnGameOver);
            _eventBus.Subscribe<RelocateObjectSpawnPositionEvent>(OnObjectSpawn);
            CreateMonster(Guid.NewGuid().ToString(),monsterSpeed);
            _monster.PropertyChanged += OnPropertyChanged;
        }

        private void CreateMonster(string id,float monsterSpeed)
        {
            _monster = new Monster(id,monsterSpeed);
        }

        private void OnObjectSpawn(RelocateObjectSpawnPositionEvent evt)
        {
            if(evt.ObjectId==_monster.MonsterId)
                RelocateToSpawnPoint?.Invoke(evt.PosX,evt.PosY,evt.PosZ);
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
            _eventBus.Unsubscribe<RelocateObjectSpawnPositionEvent>(OnObjectSpawn);
            _monster.PropertyChanged -= OnPropertyChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
