using Component_Models;
using Component_Models.Contracts;
using Core.Player.Scripts.Component_Models;
using Events;
using Installers;
using Modules.Player.Scripts;

namespace Builder
{
    public class PlayerDeathComponentModelBuilder : ComponentModelBuilder
    {
        private IPlayerDeathComponentModel _componentModel;
        public override void Create()
        {
            _componentModel = new PlayerDeathComponentModel(ServiceLocator.Instance.GetService<IEventBus>(),ServiceLocator.Instance.GetService<IPlayerRepository>());
        }

        public IPlayerDeathComponentModel GetPlayerDeathComponentModel() => _componentModel;
    }
}