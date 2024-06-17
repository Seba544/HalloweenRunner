using System;
using Component_Models.Contracts;
using Events;
using Models;
using Candy = Models.Candy;

namespace Component_Models
{
    public class CandyComponentModel : ICandyComponentModel
    {
        private readonly IEventBus _eventBus;
        private readonly int _amount;
        private ICandy _candy;
        public CandyComponentModel(IEventBus eventBus, int amount)
        {
            _eventBus = eventBus;
            _eventBus.Subscribe<RelocateObjectSpawnPositionEvent>(OnObjectSpawn);
            _amount = amount;
            CreateCandy(Guid.NewGuid().ToString(),_amount);
        }

        private void OnObjectSpawn(RelocateObjectSpawnPositionEvent evt)
        {
            if (evt.ObjectId == _candy.CandyId)
            {
                RelocateToSpawnPoint?.Invoke(evt.PosX,evt.PosY,evt.PosZ);
            }
        }

        public void CollectCandy()
        {
            int amountToColllect = _candy.Collect();
            var collectCandyEvent = new CollectCandyEvent(amountToColllect);
            _eventBus.Publish(collectCandyEvent);
        }

        public string GetCandyId() => _candy.CandyId;

        public event Action<float, float, float> RelocateToSpawnPoint;

        private void CreateCandy(string candyId,int amount)
        {
            _candy = new Candy(candyId, amount);
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<RelocateObjectSpawnPositionEvent>(OnObjectSpawn);
        }
    }
}
