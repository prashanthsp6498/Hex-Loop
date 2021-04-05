using TMPro;
using UnityEngine;

namespace HexLoop.Manager.UI
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        private void Start()
        {
            scoreText.text = $"Score: { 0 }";
        }

        public void UpdateScore(int score)
        {
            scoreText.text = $"Score: {score}";
        }

    }
}