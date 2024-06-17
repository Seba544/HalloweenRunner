using Component_Models;
using Component_Models.Contracts;
using Events;
using Installers;

namespace Builder
{
    public class CandyComponentModelBuilder : ComponentModelBuilder
    {
        private readonly int _amount;
        private ICandyComponentModel _componentModel;

        public CandyComponentModelBuilder(int amount)
        {
            _amount = amount;
        }
        
        public override void Create()
        {
            _componentModel = new CandyComponentModel(ServiceLocator.Instance.GetService<IEventBus>(),_amount);
        }

        public ICandyComponentModel GetCandyComponentModel() => _componentModel;
    }
}