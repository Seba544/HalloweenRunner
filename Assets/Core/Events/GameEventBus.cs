using System;
using System.Collections.Generic;
using System.Linq;

namespace Events
{
    public class GameEventBus : IEventBus
    {
        private readonly Dictionary<Type, List<Delegate>> events = new();
        public void Subscribe<TEvent>(Action<TEvent> action)
        {
            var eventType = typeof(TEvent);
            if (!events.ContainsKey(eventType)) events.Add(eventType, new List<Delegate>());
            events[eventType].Add(action);
        }

        public void Unsubscribe<TEvent>(Action<TEvent> action)
        {
            var eventType = typeof(TEvent);
            if (events.ContainsKey(eventType))
            {
                var actions = events[eventType];
                events[eventType].Remove(action);
            }
        }

        public void Publish<TEvent>(TEvent eventData)
        {
            var eventType = typeof(TEvent);
            if (events.ContainsKey(eventType))
                foreach (Action<TEvent> action in events[eventType].ToList())
                    action?.Invoke(eventData);
        }
    }
}