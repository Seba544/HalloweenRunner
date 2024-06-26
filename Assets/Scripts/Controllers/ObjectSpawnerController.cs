using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Events;

namespace Controllers
{
    public class ObjectSpawnerController : IObjectSpawnerController
    {
        private readonly IEventBus _eventBus;
        private bool _isGameOver;
        public bool IsGameOver
        {
            get => _isGameOver;
            set
            {
                if (value != _isGameOver)
                {
                    _isGameOver = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObjectSpawnerController(IEventBus eventBus)
        {
            _eventBus = eventBus;
            _eventBus.Subscribe<GameOverEvent>(OnGameOver);
        }

        private void OnGameOver(GameOverEvent evt)
        {
            IsGameOver = true;
        }

        public void RelocateObjectSpawnPosition(string objectId,float posX, float posY, float posZ)
        {
            RelocateObjectSpawnPositionEvent relocateObjectSpawnPositionEvent = new RelocateObjectSpawnPositionEvent(objectId,posX,posY,posZ);
            _eventBus.Publish(relocateObjectSpawnPositionEvent);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<GameOverEvent>(OnGameOver);
        }
    }
}