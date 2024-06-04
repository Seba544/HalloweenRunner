using Component_Models.Contracts;
using Events;

namespace Component_Models
{
    public class CandyComponentModel : ICandyComponentModel
    {
        private readonly IEventBus _eventBus;

        public CandyComponentModel(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        public void CollectCandy()
        {
            var collectCandyEvent = new CollectCandyEvent();
            _eventBus.Publish(collectCandyEvent);
        }

        public void Dispose(){}
    }
}
