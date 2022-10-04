namespace Model.Execution
{
    public class GameLoop : IGameLoop
    {
        private readonly GenericLoop<IUpdatable> _updateLoop = new GenericLoop<IUpdatable>();
        private readonly GenericLoop<IFixedUpdatable> _fixedUpdateLoop = new GenericLoop<IFixedUpdatable>();

        public GameLoop ThenUpdate<T>() where T : IUpdatable
        {
            _updateLoop.AddToOrder<T>();
            return this;
        }

        public GameLoop ThenFixedUpdate<T>() where T : IFixedUpdatable
        {
            _fixedUpdateLoop.AddToOrder<T>();
            return this;
        }

        public void AddUpdate(IUpdatable updatable)
        {
            _updateLoop.Add(updatable);
        }

        public void RemoveUpdate(IUpdatable updatable)
        {
            _updateLoop.Remove(updatable);
        }

        public void AddFixedUpdate(IFixedUpdatable fixedUpdatable)
        {
            _fixedUpdateLoop.Add(fixedUpdatable);
        }

        public void RemoveFixedUpdate(IFixedUpdatable fixedUpdatable)
        {
            _fixedUpdateLoop.Remove(fixedUpdatable);
        }

        public void Update(float deltaTime)
        {
            foreach (var item in _updateLoop.Read())
            {
                item.Update(deltaTime);
            }
        }

        public void FixedUpdate(float deltaTime)
        {
            foreach (var item in _fixedUpdateLoop.Read())
            {
                item.FixedUpdate(deltaTime);
            }
        }
    }
}