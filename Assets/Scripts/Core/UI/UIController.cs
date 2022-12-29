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

        private void Start() => GameFactory.Get<ScoreModel>().AddScoreCallback(UpdatePlayerScore);

        private void UpdatePlayerScore(int score) => scoreView.UpdateScore(score);

        public void SubscribeToManager() => GameFactory.Subscribe(this);
    }
}