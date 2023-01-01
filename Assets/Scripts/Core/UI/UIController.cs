using UnityEngine;
using HexLoop.Core.ScoreSystem;
using HexLoop.Core.ManagerUtil;

namespace HexLoop.Core.UI
{
    public class UIController : MonoBehaviour, IFactoryItem
    {
        [SerializeField] private ScoreUI scoreView;
        [SerializeField] private ScoreModel scoreModel;

        private void OnEnable() => SubscribeToManager();

        private void Start() => AddScoreListener();

        private void AddScoreListener()
        {
            var scoreModel = GameFactory.Get<ScoreModel>();
            if (scoreModel == null)
                return;
            scoreModel.AddScoreCallback(UpdatePlayerScore);
            scoreModel.AddBestScoreCallback(UpdatePlayerBestScore);
        }

        private void UpdatePlayerScore(int score) => scoreView.UpdateScore(score);

        private void UpdatePlayerBestScore(int bestScore) => scoreView.UpdateBestScore(bestScore);

        public void SubscribeToManager() => GameFactory.Subscribe(this);
    }
}