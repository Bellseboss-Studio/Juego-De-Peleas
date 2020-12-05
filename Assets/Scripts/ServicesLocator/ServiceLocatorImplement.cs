using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace ServiceLocator
{
    public class ServiceLocatorImplement
    {
        public static ServiceLocatorImplement Instancie => _instance ?? (_instance = new ServiceLocatorImplement());
        private static ServiceLocatorImplement _instance;

        private readonly Dictionary<Type, object> _services;

        private ServiceLocatorImplement()
        {
            _services = new Dictionary<Type, object>();
        }
        public void RegisterService<T>(T service)
        {
            var type = typeof(T);
            Assert.IsFalse(_services.ContainsKey(type),
                           $"Service {type} already registered");

            _services.Add(type, service);
        }

        public T GetService<T>()
        {
            var type = typeof(T);
            if (!_services.TryGetValue(type, out var service))
            {
                throw new Exception($"Service {type} not found");
            }

            return (T)service;
        }
    }
}