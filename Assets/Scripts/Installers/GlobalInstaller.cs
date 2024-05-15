using UnityEngine;

namespace Installers
{
    [DefaultExecutionOrder(-500)]
    public class GlobalInstaller : MonoBehaviour
    {
        #region Private Fields

        [SerializeField] private Installer[] _installers;

        #endregion Private Fields
        
        private void Awake()
        {
            InstallDependencies();
        }

        private void InstallDependencies()
        {
            foreach (var installer in _installers) installer.Install(ServiceLocator.Instance);
        }

    }
}