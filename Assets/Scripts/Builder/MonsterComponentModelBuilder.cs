using Component_Models;
using Component_Models.Contracts;
using Core.Monsters.Scripts.Component_Models;
using Events;
using Installers;

namespace Builder
{
    public class MonsterComponentModelBuilder : ComponentModelBuilder
    {
        private IMonsterComponentModel _componentModel;
        private float _monsterSpeed;

        public MonsterComponentModelBuilder(float monsterSpeed)
        {
            _monsterSpeed = monsterSpeed;
        }
        public override void Create()
        {
            _componentModel = new MonsterComponentModel(ServiceLocator.Instance.GetService<IEventBus>(),_monsterSpeed);
        }

        public IMonsterComponentModel GetMonsterComponentModel() => _componentModel;
    }
}