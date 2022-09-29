using Model;
using UnityEngine;

namespace View
{
    public class PositionView : MonoBehaviour
    {
        private IPositionable _positionable;

        public void Init(IPositionable positionable)
        {
            _positionable = positionable;
            _positionable.PositionChanged += SetPosition;
            SetPosition(_positionable.Position);
        }

        private void OnDestroy()
        {
            _positionable.PositionChanged -= SetPosition;
        }

        private void SetPosition(Vector2 position)
        {
            transform.position = position;
        }
    }
}