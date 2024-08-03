using Core.Levels.Scripts;
using Events;
using Installers;
using Modules.Player.Scripts;

namespace Builder.Controllers
{
    public class RaceControllerBuilder : ControllerBuilder
    {
        private readonly IRace _race;
        private IRaceController _raceController;

        public RaceControllerBuilder(IRace race)
        {
            _race = race;
        }
        public override void Create()
        {
            _raceController = new RaceController(_race, ServiceLocator.Instance.GetService<IPlayerRepository>(),ServiceLocator.Instance.GetService<IEventBus>());
        }

        public IRaceController GetRaceController() => _raceController;
    }
}