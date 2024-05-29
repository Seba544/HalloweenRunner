using Installers;
using Modules.Player.Scripts;

namespace Builder
{
    public class JumpComponentModelBuilder : ComponentModelBuilder
    {
        private IJumpComponentModel _componentModel;
        private IJump _component;

        public JumpComponentModelBuilder(IJump component)
        {
            _component = component;
        }
        public override void Create()
        {
            _componentModel =
                new JumpComponentModel(_component, ServiceLocator.Instance.GetService<IPlayerRepository>());
        }

        public IJumpComponentModel GetComponentModel() => _componentModel;
    }
}