using UnityEngine;

namespace Model.GameMap
{
    public interface IMap
    {
        Bounds Bounds { get; }
        Vector2 RandomInnerPoint();
        Vector2 RandomOuterPoint();
    }
}