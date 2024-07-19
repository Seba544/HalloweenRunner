using Controllers;
using Events;
using Installers;

namespace Builder.Controllers
{
    public class ObjectSpawnerControllerBuilder : ControllerBuilder
    {
        private ObjectSpawnerController _controller;
        public override void Create()
        {
            _controller = new ObjectSpawnerController(ServiceLocator.Instance.GetService<IEventBus>());
        }

        public IObjectSpawnerController GetObjectSpawnerController() => _controller;
    }
}