using Components.Contracts;
using Contracts;
using Controllers;
using Events;
using Installers;

namespace Builder
{
    public class ResumeGameCountdownControllerBuilder : ControllerBuilder
    {
        private readonly IResumeGameCountdown _component;
        private IResumeGameCountdownController _countdownComponentModel;

        public ResumeGameCountdownControllerBuilder(IResumeGameCountdown component)
        {
            _component = component;
        }

        public override void Create()
        {
            _countdownComponentModel = new ResumeGameCountdownController(_component,ServiceLocator.Instance.GetService<IEventBus>());
        }

        public IResumeGameCountdownController GetComponentModel() => _countdownComponentModel;
    }
}
