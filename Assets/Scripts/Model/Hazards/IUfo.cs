namespace Model.Hazards
{
    public interface IUfo : IPositionable, IDestroyable
    {
        void FixedUpdate(float deltaTime);
        void Destroy();
    }
}