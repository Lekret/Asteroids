using Game;

namespace Infrastructure
{
    public class InputRouter
    {
        private readonly PlayerControls _controls = new PlayerControls();
        private readonly Ship _ship;

        public InputRouter(Ship ship)
        {
            _ship = ship;
        }

        public void Route()
        {
            _controls.ShipMap.Movement.performed += context =>
            {
                
            };
        }
    }
}