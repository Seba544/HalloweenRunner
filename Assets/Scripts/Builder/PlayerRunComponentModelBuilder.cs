using Component_Models;
using Component_Models.Contracts;
using Installers;
using Modules.Player.Scripts;

namespace Builder
{
    public class PlayerRunComponentModelBuilder : ComponentModelBuilder
    {
        private IPlayerRunComponentModel _componentModel;

        public override void Create()
        {
            _componentModel = new PlayerRunComponentModel(ServiceLocator.Instance.GetService<IPlayerRepository>());
        }

        public IPlayerRunComponentModel GetPlayerRunComponentModel() => _componentModel;
    }
}
