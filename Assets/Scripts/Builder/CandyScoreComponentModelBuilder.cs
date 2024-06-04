using Component_Models;
using Component_Models.Contracts;
using Events;
using Installers;

namespace Builder
{
    public class CandyScoreComponentModelBuilder : ComponentModelBuilder
    {
        private ICandyScoreComponentModel _componentModel;
        public override void Create()
        {
            _componentModel = new CandyScoreComponentModel(ServiceLocator.Instance.GetService<IEventBus>());
        }

        public ICandyScoreComponentModel GetCandyScoreComponentModel() => _componentModel;
    }
}