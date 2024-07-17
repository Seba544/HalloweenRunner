using System;
using Component_Models.Contracts;
using Components.Contracts;
using Contracts;
using Events;

namespace Controllers
{
    public class ResumeGameCountdownController : IResumeGameCountdownController
    {
        private IResumeGameCountdown _component;
        private IEventBus _eventBus;

        public ResumeGameCountdownController(IResumeGameCountdown component,IEventBus eventBus)
        {
            _component = component;
            _eventBus = eventBus;

            _component.FinishCountdown += OnFinishCountdown;
            _eventBus.Subscribe<ResumeGameCountdownEvent>(OnResumeGameCountdownEvent);
        }

        private void OnFinishCountdown()
        {
            var resumeGameEvent = new ResumeGameEvent();
            _eventBus.Publish(resumeGameEvent);
        }

        public event Action InitCountdown = () => {};

        private void OnResumeGameCountdownEvent(ResumeGameCountdownEvent _)
        {
            InitCountdown?.Invoke();
        }

        public void Dispose()
        {
            _component.FinishCountdown -= OnFinishCountdown;
            _eventBus.Unsubscribe<ResumeGameCountdownEvent>(OnResumeGameCountdownEvent);
            
        }
        

    }
}