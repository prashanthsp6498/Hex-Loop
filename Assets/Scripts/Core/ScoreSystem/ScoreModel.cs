using UnityEngine;
using System;
using System.IO;
using HexLoop.Core.ManagerUtil;

namespace HexLoop.Core.ScoreSystem
{
    public class ScoreModel : MonoBehaviour, IFactoryItem
    {
        public ScoreSystem ScoreSystem => _scoreSystem;

        private ScoreSystem _scoreSystem;
        private const string ScoreBinFileName = "score.bin";
        private string _savePath;

        private void Awake()
        {
            _savePath = Path.Combine(Application.persistentDataPath, "GameBin");
            SubscribeToManager();
            _scoreSystem = BinarySaverWrapper.Read<ScoreSystem>(Path.Combine(_savePath, ScoreBinFileName)) ?? new();
        }

        private void OnDestroy() => BinarySaverWrapper.Write(_scoreSystem, _savePath, ScoreBinFileName);

        public void IncrementScore() => _scoreSystem.Increment();

        public void AddScoreCallback(Action<int> scoreCallback) => _scoreSystem?.AddScoreChangeCallback(scoreCallback);
        public void AddBestScoreCallback(Action<int> bestScoreCallback) => _scoreSystem?.AddBestScoreChangeCallback(bestScoreCallback);

        public void SubscribeToManager() => GameFactory.Subscribe(this);
    }
}
