using Model.Obstacles;

namespace Infrastructure
{
    public class GameLoop
    {
        private readonly IObstacleSpawner _obstacleSpawner;

        public GameLoop(IObstacleSpawner obstacleSpawner)
        {
            _obstacleSpawner = obstacleSpawner;
        }

        public void Update(float deltaTime)
        {
            _obstacleSpawner.Update(deltaTime);
        }
    }
}