using UnityEngine;

namespace Installers
{
    public abstract class Installer : MonoBehaviour
    {
        public abstract void Install(ServiceLocator serviceLocator);
    }
}