using Model.Obstacles;
using UnityEngine;

namespace View
{
    public class UfoView : MonoBehaviour
    {
        private IUfo _ufo;
        
        public void Init(IUfo ufo)
        {
            _ufo = ufo;
            _ufo.PositionChanged += SetPosition;
            SetPosition(_ufo.Position);
        }

        private void OnDestroy()
        {
            _ufo.PositionChanged -= SetPosition;
        }
        
        private void Update()
        {
            _ufo.Update(Time.deltaTime);
        }
        
        private void SetPosition(Vector2 position)
        {
            transform.position = position;
        }
    }
}