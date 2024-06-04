using Component_Models;
using Component_Models.Contracts;
using Components.Contracts;
using Events;
using Installers;

namespace Builder
{
    public class ResumeGameCountdownComponentModelBuilder : ComponentModelBuilder
    {
        private readonly IResumeGameCountdown _component;
        private IResumeGameCountdownComponentModel _countdownComponentModel;

        public ResumeGameCountdownComponentModelBuilder(IResumeGameCountdown component)
        {
            _component = component;
        }

        public override void Create()
        {
            _countdownComponentModel = new ResumeGameCountdownComponentModel(_component,ServiceLocator.Instance.GetService<IEventBus>());
        }

        public IResumeGameCountdownComponentModel GetComponentModel() => _countdownComponentModel;
    }
}
