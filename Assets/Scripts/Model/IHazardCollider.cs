using Model.Hazards;

namespace Model
{
    public interface IHazardCollider
    {
        void CollideWith(IAsteroid asteroid);
        void CollideWith(IUfo ufo);
    }
}