using System;
using HexLoop.Core.Log;

namespace HexLoop.Core.ScoreSystem
{
    [Serializable]
    public class ScoreSystem
    {
        private int _bestScore;
        [NonSerialized] private int _score;
        [NonSerialized] private Action<int> OnScoreChangeCallback;
        [NonSerialized] private Action<int> OnBestScoreChangeCallback;

        public int Score => _score;

        public ScoreSystem() { }

        public ScoreSystem(Action<int> onScoreChangeCallback) => OnScoreChangeCallback = onScoreChangeCallback;

        public void AddScoreChangeCallback(Action<int> onScoreChangeCallback)
        {
            OnScoreChangeCallback += onScoreChangeCallback;
            BroadcastScoreToListeners();
        }

        public void AddBestScoreChangeCallback(Action<int> onBestScoreChangeCallback)
        {
            OnBestScoreChangeCallback += onBestScoreChangeCallback;
            BroadcastBestScoreToListeners();
        }

        public void Increment()
        {
            ++_score;
            CheckForBestScore();
            Logger.Assert(OnScoreChangeCallback == null, $"No listener subscribed for Score callback");
            BroadcastScoreToListeners();
        }

        private void CheckForBestScore()
        {
            if (_bestScore >= _score)
                return;

            _bestScore = _score;
            Logger.Assert(OnScoreChangeCallback == null, $"No listener subscribed for BestScore callback");
            OnBestScoreChangeCallback?.Invoke(_bestScore);
        }

        public void BroadcastScoreToListeners() => OnScoreChangeCallback?.Invoke(_score);
        public void BroadcastBestScoreToListeners() => OnBestScoreChangeCallback?.Invoke(_bestScore);
    }
}
