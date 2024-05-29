using System;

namespace Events
{
    public interface IEventBus
    {
        public void Subscribe<TEvent>(Action<TEvent> action);

        void Unsubscribe<TEvent>(Action<TEvent> action);
        void Publish<TEvent>(TEvent eventData);
    }
}