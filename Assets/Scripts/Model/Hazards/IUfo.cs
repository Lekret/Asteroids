namespace Model.Hazards
{
    public interface IUfo : IPositionable, IDestroyable
    {
        void Update(float deltaTime);
    }
}