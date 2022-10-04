namespace Model.Hazards
{
    public interface IAsteroid : IPositionable, IDestroyable
    {
        void Destroy();
        void Shatter();
    }
}