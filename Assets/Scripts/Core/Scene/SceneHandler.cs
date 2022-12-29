using UnityEngine;
using HexLoop.Core.ManagerUtil;
using UnityEngine.SceneManagement;

namespace HexLoop.Core.Scene
{
    public class SceneHandler : MonoBehaviour, IFactoryItem
    {
        private void OnEnable() => SubscribeToManager();

        public void GameOverScene() => SceneManager.LoadScene(2);

        public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        public void Quit() => Application.Quit();

        public void GameScene() => SceneManager.LoadScene(1);

        public void SubscribeToManager() => GameFactory.Subscribe(this);
    }
}
