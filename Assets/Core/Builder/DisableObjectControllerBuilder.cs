using Assets.Scripts.Components.Contracts;
using Assets.Scripts.Controllers;
using Builder;
using Events;
using Installers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Builder
{
    public class DisableObjectControllerBuilder : ControllerBuilder
    {
        private readonly IDisableObject _component;
        private IDisableObjectController _controller;

        public DisableObjectControllerBuilder(IDisableObject component) {
            _component = component;
        }
        public override void Create()
        {
            _controller = new DisableObjectController(_component, ServiceLocator.Instance.GetService<IEventBus>());
        }

        public IDisableObjectController GetDisableObjectController() => _controller;
    }
}
