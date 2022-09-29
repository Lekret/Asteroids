namespace Model.Obstacles
{
    public interface IUfo : IPositionable, IDestroyable
    {
        void Update(float deltaTime);
    }
}