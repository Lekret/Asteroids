using System.Collections.Generic;

namespace Model.Execution
{
    public class FixedUpdateLoop
    {
        private readonly HashSet<IFixedUpdatable> _items = new HashSet<IFixedUpdatable>();
        private readonly List<IFixedUpdatable> _readBuffer = new List<IFixedUpdatable>();
        
        public void Add(IFixedUpdatable fixedUpdatable)
        {
            _items.Add(fixedUpdatable);
        }

        public void Remove(IFixedUpdatable fixedUpdatable)
        {
            _items.Remove(fixedUpdatable);
        }

        public void FixedUpdate(float deltaTime)
        {
            _readBuffer.Clear();
            _readBuffer.AddRange(_items);
            foreach (var fixedUpdatable in _readBuffer)
            {
                fixedUpdatable.FixedUpdate(deltaTime);
            }
        }
    }
}