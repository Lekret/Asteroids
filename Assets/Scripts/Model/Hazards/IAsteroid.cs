namespace Model.Hazards
{
    public interface IAsteroid : IPositionable, IDestroyable
    {
        void Update(float deltaTime);
    }
}