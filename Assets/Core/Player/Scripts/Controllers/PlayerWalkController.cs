using Core.Player.Scripts.Components;
using Events;
using Modules.Player.Scripts;
using UnityEngine;

namespace Core.Player.Scripts.Controllers
{
    public class PlayerWalkController : IPlayerWalkController
    {
        private readonly IPlayerWalk _playerWalk;
        private readonly IEventBus _eventBus;
        private IPlayer _player;
        
        public PlayerWalkController(IPlayerWalk playerWalk,IEventBus eventBus, IPlayerRepository playerRepository)
        {
            _playerWalk = playerWalk;
            _eventBus = eventBus;
            _player = playerRepository.GetPlayer();
            _eventBus.Subscribe<PlayerStumblesAgainstObstacleEvent>(OnPlayerStumblesAgainstObstacle);
        }

        private void OnPlayerStumblesAgainstObstacle(PlayerStumblesAgainstObstacleEvent evt)
        {
            _playerWalk.Walk();
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<PlayerStumblesAgainstObstacleEvent>(OnPlayerStumblesAgainstObstacle);
        }

        public void ReduceSpeed()
        {
            _player.ReduceSpeed();
        }

        public void ResumeSpeed()
        {
            _player.ResumeSpeed();
        }
    }
}
