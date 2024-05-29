using Component_Models.Contracts;
using Components.Contracts;
using Events;

namespace Component_Models
{
    public class ThreeSecondsResumeGameComponentModel : IThreeSecondsResumeGameComponentModel
    {
        private IThreeSecondsResumeGame _component;
        private IEventBus _eventBus;

        public ThreeSecondsResumeGameComponentModel(IThreeSecondsResumeGame component,IEventBus eventBus)
        {
            _component = component;
            _eventBus = eventBus;
        }
    }
}