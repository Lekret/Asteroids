using Model.Hazards;
using UnityEngine;

namespace Services
{
    public interface IAsteroidFactory
    {
        IAsteroid CreateBig();
        IAsteroid CreateSmall(Vector3 position);
    }
}