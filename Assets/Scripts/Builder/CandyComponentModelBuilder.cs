using Component_Models;
using Component_Models.Contracts;
using Events;
using Installers;

namespace Builder
{
    public class CandyComponentModelBuilder : ComponentModelBuilder
    {
        private ICandyComponentModel _componentModel;
        
        public override void Create()
        {
            _componentModel = new CandyComponentModel(ServiceLocator.Instance.GetService<IEventBus>());
        }

        public ICandyComponentModel GetCandyComponentModel() => _componentModel;
    }
}