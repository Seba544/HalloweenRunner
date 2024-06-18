using Component_Models;
using Component_Models.Contracts;
using Events;
using Installers;

namespace Builder
{
    public class ObstacleComponentModelBuilder : ComponentModelBuilder
    {
        private IObstacleComponentModel _componentModel;
        public override void Create()
        {
            _componentModel = new ObstacleComponentModel(ServiceLocator.Instance.GetService<IEventBus>());
        }

        public IObstacleComponentModel GetObstacleComponentModel() => _componentModel;
    }
}