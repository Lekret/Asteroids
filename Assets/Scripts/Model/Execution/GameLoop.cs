namespace Model.Execution
{
    public class GameLoop : IGameLoop
    {
        private readonly UpdateLoop _updateLoop = new UpdateLoop();
        private readonly FixedUpdateLoop _fixedUpdateLoop = new FixedUpdateLoop();

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
            _updateLoop.Update(deltaTime);
        }

        public void FixedUpdate(float deltaTime)
        {
            _fixedUpdateLoop.FixedUpdate(deltaTime);
        }
    }
}