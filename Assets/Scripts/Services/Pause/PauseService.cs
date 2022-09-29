using UnityEngine;

namespace Services.Pause
{
    public class PauseService : IPauseService
    {
        public void Pause()
        {
            Time.timeScale = 0;
        }

        public void Unpause()
        {
            Time.timeScale = 1;
        }
    }
}