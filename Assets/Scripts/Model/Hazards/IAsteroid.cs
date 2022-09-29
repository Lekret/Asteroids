namespace Model.Hazards
{
    public interface IAsteroid : IPositionable, IDestroyable
    {
        void Update(float deltaTime);
        void FixedUpdate(float deltaTime);
        void Destroy();
        void Shatter();
    }
}