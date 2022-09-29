using Services;
using UnityEngine;

namespace Model.GameMap
{
    public class Map : IMap
    {
        private readonly Bounds _bounds;
        private readonly IRandomizer _randomizer;

        public Map(Bounds bounds, IRandomizer randomizer)
        {
            _bounds = bounds;
            _randomizer = randomizer;
        }

        public Bounds Bounds => _bounds;
        
        public Vector2 RandomOuterPoint()
        {
            var sign = _randomizer.Range(-1, 1);
            var extents = _bounds.extents;
            if (_randomizer.Range(0f, 1f) < 0.5f)
            {
                var x = _randomizer.Range(-extents.x, extents.x);
                var y = extents.y * sign;
                return new Vector2(x, y);
            }
            else
            {
                var x = extents.x * sign;
                var y = _randomizer.Range(-extents.y, extents.y);
                return new Vector2(x, y);
            }
        }
    }
}