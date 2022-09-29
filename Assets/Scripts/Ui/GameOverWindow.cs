using Services;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class GameOverWindow : MonoBehaviour
    {
        [SerializeField] private GameObject _root;
        [SerializeField] private Button _button;

        private ISceneLoader _sceneLoader;

        public void Init(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        private void Awake()
        {
            _button.onClick.AddListener(Restart);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(Restart);
        }

        private void Enable()
        {
            _root.SetActive(true);
        }
        
        private void Restart()
        {
            _sceneLoader.Restart();
        }
    }
}