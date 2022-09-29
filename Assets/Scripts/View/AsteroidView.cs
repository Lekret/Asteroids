using Model.Obstacles;
using UnityEngine;

namespace View
{
    public class AsteroidView : MonoBehaviour
    {
        [SerializeField] private PositionView _positionView;
        [SerializeField] private DestroyableView _destroyableView;
        
        private IAsteroid _asteroid;
        
        public void Init(IAsteroid asteroid)
        {
            _asteroid = asteroid;
            _positionView.Init(asteroid);
            _destroyableView.Init(asteroid);
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        }

        private void Update()
        {
            _asteroid.Update(Time.deltaTime);
        }
    }
}