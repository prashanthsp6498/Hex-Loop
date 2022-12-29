using UnityEngine;

namespace HexLoop.Core.Config
{
    public class GameConfig : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 60;
        }
    }
}
