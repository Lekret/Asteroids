namespace Model.Obstacles
{
    public interface IAsteroid : IPositionable, IDestroyable
    {
        void Update(float deltaTime);
    }
}