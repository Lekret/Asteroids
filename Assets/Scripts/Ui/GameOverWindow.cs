using Model.Score;
using Services.SceneLoader;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class GameOverWindow : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _score;

        private ISceneLoader _sceneLoader;

        public void Init(ISceneLoader sceneLoader, IScoreTracker scoreTracker)
        {
            _sceneLoader = sceneLoader;
            _score.text = $"Score: {scoreTracker.Score}";
        }
        
        private void Awake()
        {
            _button.onClick.AddListener(Restart);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(Restart);
        }

        private void Restart()
        {
            _sceneLoader.Restart();
        }
    }
}