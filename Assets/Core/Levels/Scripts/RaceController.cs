using Events;
using Modules.Player.Scripts;

namespace Core.Levels.Scripts
{
    public class RaceController : IRaceController
    {
        private readonly IRace _race;
        private readonly IPlayerRepository _playerRepository;
        private readonly IEventBus _eventBus;
        private IPlayer _player;

        public RaceController(IRace race, IPlayerRepository playerRepository, IEventBus eventBus)
        {
            _race = race;
            _playerRepository = playerRepository;
            _eventBus = eventBus;
            
        }

        public void SetRaceDifficultyToMedium()
        {
            _player.IncreaseSpeed(1f);
        }

        public void SetRaceDifficultyToHard()
        {
            _player.IncreaseSpeed(1f);
        }

        public void EndRace()
        {
            
        }

        public void StartRace()
        {
            _player = _playerRepository.GetPlayer();
        }
    }
}
