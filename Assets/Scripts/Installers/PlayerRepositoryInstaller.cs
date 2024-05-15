using Modules.Player.Scripts;

namespace Installers
{
    public class PlayerRepositoryInstaller : Installer
    {
        public override void Install(ServiceLocator serviceLocator)
        {
            serviceLocator.RegisterService<IPlayerRepository>(new InMemoryPlayerRepository());
        }
    }
}