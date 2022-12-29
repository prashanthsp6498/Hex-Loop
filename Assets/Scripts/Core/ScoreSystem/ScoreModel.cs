using UnityEngine;
using System;
using HexLoop.Core.ManagerUtil;

namespace HexLoop.Core.ScoreSystem
{
    public class ScoreModel : MonoBehaviour, IFactoryItem
    {
        public ScoreSystem ScoreSystem => _scoreSystem;

        private int score = 0;
        private ScoreSystem _scoreSystem;

        private void Awake()
        {
            _scoreSystem = new();
            SubscribeToManager();
        }

        public int IncrementScore()
        {
            _scoreSystem.Increment();
            score += 1;
            return score;
        }

        public void AddScoreCallback(Action<int> scoreCallback) => _scoreSystem?.AddScoreChangeCallback(scoreCallback);

        public void SubscribeToManager() => GameFactory.Subscribe(this);
    }
}
