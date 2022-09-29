using Model.Obstacles;
using UnityEngine;

namespace View
{
    public class AsteroidView : MonoBehaviour
    {
        [SerializeField] private PositionView _positionView;
        
        private IAsteroid _asteroid;
        
        public void Init(IAsteroid asteroid)
        {
            _asteroid = asteroid;
            _positionView.Init(asteroid);
            transform.rotation = Random.rotation;
        }

        private void Update()
        {
            _asteroid.Update(Time.deltaTime);
        }
    }
}