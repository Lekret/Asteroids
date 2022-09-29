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
        
        public Vector2 RandomInnerPoint()
        {
            var point = _bounds.center;
            var extents = _bounds.extents;
            point.x += _randomizer.Range(-extents.x, extents.x);
            point.y += _randomizer.Range(-extents.y, extents.y);
            return point;
        }
        
        public Vector2 RandomOuterPoint()
        {
            var sign = _randomizer.Boolean() ? 1 : -1;
            var extents = _bounds.extents;
            if (_randomizer.Boolean())
            {
                var x = _randomizer.Range(-extents.x, extents.x);
                var y = (extents.y + 1) * sign;
                return new Vector2(x, y);
            }
            else
            {
                var x = (extents.x + 1) * sign;
                var y = _randomizer.Range(-extents.y, extents.y);
                return new Vector2(x, y);
            }
        }
    }
}