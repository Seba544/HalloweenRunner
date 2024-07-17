using Component_Models;
using Component_Models.Contracts;
using Controllers;
using Events;
using Installers;

namespace Builder
{
    public class CandyScoreControllerBuilder : ControllerBuilder
    {
        private ICandyScoreController _controller;
        public override void Create()
        {
            _controller = new CandyScoreController(ServiceLocator.Instance.GetService<IEventBus>());
        }

        public ICandyScoreController GetCandyScoreComponentModel() => _controller;
    }
}