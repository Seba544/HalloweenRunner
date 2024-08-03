using Component_Models;
using Component_Models.Contracts;
using Events;
using Installers;
using Modules.Player.Scripts;

namespace Builder
{
    public class PlayerRunControllerBuilder : ControllerBuilder
    {
        private IPlayerRunController m_controller;

        public override void Create()
        {
            m_controller = new PlayerRunController(ServiceLocator.Instance.GetService<IPlayerRepository>(),
                ServiceLocator.Instance.GetService<IEventBus>());
        }

        public IPlayerRunController GetPlayerRunComponentModel() => m_controller;
    }
}
