using UnityEngine.SceneManagement;

namespace Services.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        public void RestartCurrentScene()
        {
            var currentIdx = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentIdx);
        }
    }
}