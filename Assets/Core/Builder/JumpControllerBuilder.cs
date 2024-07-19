using Installers;
using Modules.Player.Scripts;

namespace Builder
{
    public class JumpControllerBuilder : ControllerBuilder
    {
        private IJumpController _controller;
        
        public override void Create()
        {
            _controller =
                new JumpController( ServiceLocator.Instance.GetService<IPlayerRepository>());
        }

        public IJumpController GetController() => _controller;
    }
}