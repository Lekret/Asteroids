using Services;
using UnityEngine.SceneManagement;

namespace ServicesImpl
{
    public class SceneLoader : ISceneLoader
    {
        public void Restart()
        {
            var currentIdx = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentIdx);
        }
    }
}