using Model.Obstacles;
using UnityEngine;

namespace View
{
    public class AsteroidView : MonoBehaviour
    {
        private IAsteroid _asteroid;
        
        public void Init(IAsteroid asteroid)
        {
            _asteroid = asteroid;
        }

        private void OnDestroy()
        {
            _asteroid.PositionChanged -= SetPosition;
        }
        
        private void Update()
        {
            _asteroid.Update(Time.deltaTime);
        }

        private void SetPosition(Vector2 position)
        {
            transform.position = position;
        }
    }
}