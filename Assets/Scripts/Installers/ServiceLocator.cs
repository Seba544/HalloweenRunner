using System;
using System.Collections.Generic;

namespace Installers
{
    public class ServiceLocator
    {
        private static ServiceLocator _instance;
        private readonly Dictionary<Type, object> _services = new();
        private ServiceLocator()
        {
            _services = new Dictionary<Type, object>();
        }
        public static ServiceLocator Instance => _instance ??= new ServiceLocator();
        
        public Type GetService<Type>()
        {
            var serviceType = typeof(Type);
            if (!_services.TryGetValue(serviceType, out var service))
                throw new Exception($"Service of type {serviceType} not found");
            return (Type)service;
        }

        public void RegisterService<Type>(Type service)
        {
            var serviceType = typeof(Type);
            if (!_services.TryGetValue(serviceType, out var serviceToAdd))
                _services.Add(serviceType, service);
            else
                throw new Exception($"Service {service} is already registered in ServiceLocator");
        }
    }
}