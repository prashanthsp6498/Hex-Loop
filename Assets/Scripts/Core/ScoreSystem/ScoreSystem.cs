using System;
using HexLoop.Core.Log;

namespace HexLoop.Core.ScoreSystem
{
    public class ScoreSystem
    {
        private int _score;
        private Action<int> OnScoreChangeCallback;

        public int Score => _score;

        public ScoreSystem() { }

        public ScoreSystem(Action<int> onScoreChangeCallback) => OnScoreChangeCallback = onScoreChangeCallback;

        public void AddScoreChangeCallback(Action<int> onScoreChangeCallback) => OnScoreChangeCallback += onScoreChangeCallback;

        public void Increment()
        {
            ++_score;
            Logger.Assert(OnScoreChangeCallback == null, $"No listener subscribed for callback");
            OnScoreChangeCallback?.Invoke(_score);
        }
    }
}
