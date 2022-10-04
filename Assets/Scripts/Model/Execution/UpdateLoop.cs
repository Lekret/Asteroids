using System.Collections.Generic;

namespace Model.Execution
{
    public class UpdateLoop
    {
        private readonly HashSet<IUpdatable> _items = new HashSet<IUpdatable>();
        private readonly List<IUpdatable> _readBuffer = new List<IUpdatable>();
        
        public void Add(IUpdatable updatable)
        {
            _items.Add(updatable);
        }
        
        public void Remove(IUpdatable updatable)
        {
            _items.Remove(updatable);
        }
        
        public void Update(float deltaTime)
        {
            _readBuffer.Clear();
            _readBuffer.AddRange(_items);
            foreach (var updatable in _readBuffer)
            {
                updatable.Update(deltaTime);
            }
        }
    }
}