using System;
using System.Collections.Generic;
using UnityEngine;

namespace Model.Execution
{
    public class GenericLoop<T> where T : class
    {
        private readonly Dictionary<Type, HashSet<T>> _items = new Dictionary<Type, HashSet<T>>();
        private readonly List<T> _readBuffer = new List<T>();
        private readonly List<Type> _order = new List<Type>();

        public void Add(T item)
        {
            var itemType = item.GetType();
            if (!_items.TryGetValue(itemType, out var items))
            {
                items = new HashSet<T>();
                _items[itemType] = items;
                if (!_order.Contains(itemType))
                    _order.Insert(0, itemType);
            }
            items.Add(item);
        }
        
        public void Remove(T item)
        {
            if (_items.TryGetValue(item.GetType(), out var items))
            {
                items.Remove(item);
            }
        }
        
        public void AddToOrder<TItem>()
        {
            if (_order.Contains(typeof(TItem)))
            {
                Debug.LogError($"Type is already added to order {typeof(TItem)}");
                return;
            }
            _order.Add(typeof(TItem));
        }
        
        public List<T> Read()
        {
            _readBuffer.Clear();
            foreach (var type in _order)
            {
                if (_items.TryGetValue(type, out var items))
                {
                    _readBuffer.AddRange(items);
                }
            }
            return _readBuffer;
        }
    }
}