using Assets.Scripts.Components.Contracts;
using Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Controllers
{
    public class DisableObjectController : IDisableObjectController
    {
        private readonly IDisableObject _component;
        private readonly IEventBus _eventBus;

        public DisableObjectController(IDisableObject component,IEventBus eventBus) {
            _component = component;
            _eventBus = eventBus;

            _eventBus.Subscribe<GameOverEvent>(OnGameOver);
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<GameOverEvent>(OnGameOver);
        }

        private void OnGameOver(GameOverEvent evt)
        {
            _component.GameOver();
        }
    }
}
