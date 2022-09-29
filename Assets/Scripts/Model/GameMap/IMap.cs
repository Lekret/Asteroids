using UnityEngine;

namespace Model.GameMap
{
    public interface IMap
    {
        Bounds Bounds { get; }
        Vector2 RandomOuterPoint();
    }
}