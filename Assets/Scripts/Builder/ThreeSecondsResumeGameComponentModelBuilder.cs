using Component_Models;
using Component_Models.Contracts;
using Components.Contracts;
using Events;
using Installers;

namespace Builder
{
    public class ThreeSecondsResumeGameComponentModelBuilder : ComponentModelBuilder
    {
        private readonly IThreeSecondsResumeGame _component;
        private IThreeSecondsResumeGameComponentModel _componentModel;

        public ThreeSecondsResumeGameComponentModelBuilder(IThreeSecondsResumeGame component)
        {
            _component = component;
        }

        public override void Create()
        {
            _componentModel = new ThreeSecondsResumeGameComponentModel(_component,ServiceLocator.Instance.GetService<IEventBus>());
        }

        public IThreeSecondsResumeGameComponentModel GetComponentModel() => _componentModel;
    }
}
