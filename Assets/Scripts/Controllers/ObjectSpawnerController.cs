using Events;

namespace Controllers
{
    public class ObjectSpawnerController : IObjectSpawnerController
    {
        private readonly IEventBus _eventBus;

        public ObjectSpawnerController(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void RelocateObjectSpawnPosition(string objectId,float posX, float posY, float posZ)
        {
            RelocateObjectSpawnPositionEvent relocateObjectSpawnPositionEvent = new RelocateObjectSpawnPositionEvent(objectId,posX,posY,posZ);
            _eventBus.Publish(relocateObjectSpawnPositionEvent);
        }
    }
}