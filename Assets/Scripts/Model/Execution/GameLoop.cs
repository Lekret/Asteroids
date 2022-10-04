using System.Collections.Generic;

namespace Model.Execution
{
    public class GameLoop : IGameLoop
    {
        private readonly HashSet<IUpdatable> _updates = new HashSet<IUpdatable>();
        private readonly HashSet<IFixedUpdatable> _fixedUpdates = new HashSet<IFixedUpdatable>();
        private readonly List<IUpdatable> _updatesReadBuffer = new List<IUpdatable>();
        private readonly List<IFixedUpdatable> _fixedUpdatesReadBuffer = new List<IFixedUpdatable>();

        public void AddUpdate(IUpdatable updatable)
        {
            _updates.Add(updatable);
        }
        
        public void RemoveUpdate(IUpdatable updatable)
        {
            _updates.Remove(updatable);
        }

        public void AddFixedUpdate(IFixedUpdatable fixedUpdatable)
        {
            _fixedUpdates.Add(fixedUpdatable);
        }

        public void RemoveFixedUpdate(IFixedUpdatable fixedUpdatable)
        {
            _fixedUpdates.Remove(fixedUpdatable);
        }

        public void Update(float deltaTime)
        {
            _updatesReadBuffer.Clear();
            _updatesReadBuffer.AddRange(_updates);
            foreach (var updatable in _updatesReadBuffer)
            {
                updatable.Update(deltaTime);
            }
        }

        public void FixedUpdate(float deltaTime)
        {
            _fixedUpdatesReadBuffer.Clear();
            _fixedUpdatesReadBuffer.AddRange(_fixedUpdates);
            foreach (var fixedUpdatable in _fixedUpdatesReadBuffer)
            {
                fixedUpdatable.FixedUpdate(deltaTime);
            }
        }
    }
}