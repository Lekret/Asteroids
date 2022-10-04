using Model.Execution;
using Model.Hazards;
using Model.PlayerShip;
using Model.PlayerShip.Weapon;

namespace Infrastructure
{
    public static class GameLoopExtensions
    {
        public static GameLoop AddDefaultExecutionOrder(this GameLoop gameLoop)
        {
            return gameLoop
                .ThenUpdate<HazardSpawner>()
                .ThenUpdate<Ship>()
                .ThenUpdate<Bullet>()
                .ThenUpdate<Laser>()
                .ThenUpdate<Asteroid>()
                .ThenFixedUpdate<Ship>()
                .ThenFixedUpdate<Bullet>()
                .ThenFixedUpdate<Asteroid>()
                .ThenFixedUpdate<Ufo>();
        }
    }
}