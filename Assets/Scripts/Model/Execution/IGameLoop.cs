namespace Model.Execution
{
    public interface IGameLoop
    {
        void AddUpdate(IUpdatable updatable);
        void RemoveUpdate(IUpdatable updatable);
        void AddFixedUpdate(IFixedUpdatable fixedUpdatable);
        void RemoveFixedUpdate(IFixedUpdatable fixedUpdatable);
    }
}