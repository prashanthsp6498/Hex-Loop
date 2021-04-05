using UnityEngine;
using UnityEngine.SceneManagement;

namespace HexLoop.Manager
{
    public class SceneHandler : MonoBehaviour
    {
    
        public void GameOverScene()
        {
            SceneManager.LoadScene(2);
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void GameScene()
        {
            SceneManager.LoadScene(1);
        }
    }
}
