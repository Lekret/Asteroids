using Model.Hazards;

namespace Infrastructure
{
    public class GameLoop
    {
        private readonly IHazardSpawner _hazardSpawner;

        public GameLoop(IHazardSpawner hazardSpawner)
        {
            _hazardSpawner = hazardSpawner;
        }

        public void Update(float deltaTime)
        {
            _hazardSpawner.Update(deltaTime);
        }
    }
}