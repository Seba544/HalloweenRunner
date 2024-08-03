using Core.Player.Scripts.Controllers;
using Events;
using Installers;
using Modules.Player.Scripts;

namespace Builder.Controllers
{
    public class PlayerInitializerControllerBuilder : ControllerBuilder
    {
        private IPlayerInitializerController _playerInitializerController;
        public override void Create()
        {
            _playerInitializerController = new PlayerInitializerController(ServiceLocator.Instance.GetService<IEventBus>(),ServiceLocator.Instance.GetService<IPlayerRepository>());
        }

        public IPlayerInitializerController GetPlayerInitializerController() => _playerInitializerController;
    }
}