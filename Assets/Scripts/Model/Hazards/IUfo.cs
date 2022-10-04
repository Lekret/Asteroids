namespace Model.Hazards
{
    public interface IUfo : IPositionable, IDestroyable
    {
        void Destroy();
    }
}