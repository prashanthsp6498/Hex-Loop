using System;
using System.Collections.Generic;

namespace HexLoop.Core.ManagerUtil
{
    public static class GameFactory
    {
        private static readonly Dictionary<Type, IFactoryItem> _factoryItem = new();

        public static void Subscribe<T>(T manager) where T : IFactoryItem
        {
            if (_factoryItem.TryGetValue(manager.GetType(), out IFactoryItem managerObj))
                _factoryItem[manager.GetType()] = manager;
            else
                _factoryItem.Add(manager.GetType(), manager);
        }

        public static T Get<T>() where T : IFactoryItem
        {
            if (_factoryItem.TryGetValue(typeof(T), out IFactoryItem managerObj))
                return (T)managerObj;

            throw new Exception("Type of object trying to get is not found");
        }
    }
}
