using Component_Models;
using Component_Models.Contracts;
using Controllers;
using Events;
using Installers;

namespace Builder
{
    public class CandyControllerBuilder : ControllerBuilder
    {
        private readonly int _amount;
        private ICandyController _controller;

        public CandyControllerBuilder(int amount)
        {
            _amount = amount;
        }
        
        public override void Create()
        {
            _controller = new CandyController(ServiceLocator.Instance.GetService<IEventBus>(),_amount);
        }

        public ICandyController GetCandyComponentModel() => _controller;
    }
}