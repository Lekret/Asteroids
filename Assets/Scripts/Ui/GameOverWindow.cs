using Model.Score;
using Services.Pause;
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
        private IPauseService _pauseService;

        public void Init(
            ISceneLoader sceneLoader,
            IPauseService pauseService,
            IScoreTracker scoreTracker)
        {
            _sceneLoader = sceneLoader;
            _pauseService = pauseService;
            _score.text = $"Score: {scoreTracker.Score}";
            _pauseService.Pause();
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
            _pauseService.Unpause();
            _sceneLoader.RestartCurrentScene();
        }
    }
}