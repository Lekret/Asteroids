using Model.Hazards;
using UnityEngine;

namespace Factories
{
    public interface IAsteroidFactory
    {
        IAsteroid CreateBig();
        IAsteroid CreateSmall(Vector3 position);
    }
}