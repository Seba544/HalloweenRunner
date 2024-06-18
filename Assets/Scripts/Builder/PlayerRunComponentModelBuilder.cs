using Component_Models;
using Component_Models.Contracts;
using Events;
using Installers;
using Modules.Player.Scripts;

namespace Builder
{
    public class PlayerRunComponentModelBuilder : ComponentModelBuilder
    {
        private IPlayerRunComponentModel _componentModel;

        public override void Create()
        {
            _componentModel = new PlayerRunComponentModel(ServiceLocator.Instance.GetService<IPlayerRepository>(),
                ServiceLocator.Instance.GetService<IEventBus>());
        }

        public IPlayerRunComponentModel GetPlayerRunComponentModel() => _componentModel;
    }
}
