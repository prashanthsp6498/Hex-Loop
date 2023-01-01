using TMPro;
using UnityEngine;

namespace HexLoop.Core.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI bestScoreText;

        private void Start() => UpdateScore(0);

        public void UpdateScore(int score) => scoreText.SetText($"Score: {score}");
        public void UpdateBestScore(int bestScore) => bestScoreText.SetText($"Best Score: {bestScore}");

    }
}