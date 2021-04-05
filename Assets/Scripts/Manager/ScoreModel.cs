using UnityEngine;

namespace HexLoop.Manager
{
    public class ScoreModel : MonoBehaviour
    {
        private int score = 0;

        public int GetUpdatedScore()
        {
            score += 1;
            return score;
        }
    }
}
