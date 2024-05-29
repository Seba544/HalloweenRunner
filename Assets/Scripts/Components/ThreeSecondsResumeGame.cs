using Builder;
using Component_Models;
using Component_Models.Contracts;
using Components.Contracts;
using Events;
using Installers;
using UnityEngine;

namespace Components
{
    public class ThreeSecondsResumeGame : MonoBehaviour, IThreeSecondsResumeGame
    {
        
        private IThreeSecondsResumeGameComponentModel _componentModel;
        private void Awake()
        {
            var componentModelBuilder = new ThreeSecondsResumeGameComponentModelBuilder(this);
            componentModelBuilder.Create();
            _componentModel = componentModelBuilder.GetComponentModel();
        }
    }
}
