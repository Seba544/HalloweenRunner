using System;
using Component_Models.Contracts;
using Events;

namespace Component_Models
{
    public class ObstacleComponentModel : IObstacleComponentModel
    {
        private readonly IEventBus _eventBus;
        private string _obstacleId;
        public ObstacleComponentModel(IEventBus eventBus)
        {
            _obstacleId = Guid.NewGuid().ToString();
            _eventBus = eventBus;
            _eventBus.Subscribe<RelocateObjectSpawnPositionEvent>(OnObjectSpawn);
        }

        private void OnObjectSpawn(RelocateObjectSpawnPositionEvent evt)
        {
            if(evt.ObjectId == _obstacleId)
                RelocateToSpawnPoint?.Invoke(evt.PosX,evt.PosY,evt.PosZ);
        }

        public string GetObstacleId() => _obstacleId;
        public event Action<float, float, float> RelocateToSpawnPoint;
        public void CollidesWithPlayer(bool isASolidObstacle)
        {
            if (isASolidObstacle)
            {
                GameOverEvent gameOverEvent = new GameOverEvent();
                _eventBus.Publish(gameOverEvent);
            }
            else
            {
                PlayerStumblesAgainstObstacleEvent playerStumblesAgainstObstacleEvent =
                    new PlayerStumblesAgainstObstacleEvent();
                _eventBus.Publish(playerStumblesAgainstObstacleEvent);
            }
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<RelocateObjectSpawnPositionEvent>(OnObjectSpawn);
        }
    }
}