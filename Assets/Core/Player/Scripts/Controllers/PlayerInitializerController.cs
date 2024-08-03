using Events;
using Modules.Player.Scripts;

namespace Core.Player.Scripts.Controllers
{
    public class PlayerInitializerController : IPlayerInitializerController
    {
        private readonly IEventBus _eventBus;
        private readonly IPlayerRepository _playerRepository;

        public PlayerInitializerController(IEventBus eventBus, IPlayerRepository playerRepository)
        {
            _eventBus = eventBus;
            _playerRepository = playerRepository;
        }

        public void InitPlayer(float playerRunSpeed, float playerWalkSpeed)
        {
            _playerRepository.Create(playerRunSpeed,playerWalkSpeed);
        }
    }
}
