using Builder.Controllers;
using Core.Player.Scripts.Components;
using Core.Player.Scripts.Controllers;
using Events;
using Installers;
using Modules.Player.Scripts;

namespace Core.Builder
{
    public class PlayerWalkControllerBuilder : ControllerBuilder
    {
        private readonly IPlayerWalk _component;
        private IPlayerWalkController _controller;

        public PlayerWalkControllerBuilder(IPlayerWalk component)
        {
            _component = component;
        }
        public override void Create()
        {
            _controller = new PlayerWalkController(
                _component,
                ServiceLocator.Instance.GetService<IEventBus>(),
                ServiceLocator.Instance.GetService<IPlayerRepository>()
                );
        }

        public IPlayerWalkController GetPlayerWalkController() => _controller;
    }
    
}