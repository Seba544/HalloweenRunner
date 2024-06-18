using Component_Models;
using Component_Models.Contracts;

namespace Builder
{
    public class ChaserComponentModelBuilder : ComponentModelBuilder
    {
        private IChaserComponentModel _componentModel;
        public override void Create()
        {
            _componentModel = new ChaserComponentModel();
        }
    }
}