using UnityEngine;
using HexLoop.Core.ManagerUtil;
using HexLoop.Core.Scene;

namespace HexLoop.Core.GamePlay
{
    public class Player : MonoBehaviour
    {
        #region serializedVariables

        [SerializeField] private float movementSpeed = 500f;
        private SceneHandler _sceneHandler;

        #endregion

        #region privateVariables
        
        private float _speed = 0f;

        #endregion

        private void OnEnable()
        {
            InputHandler.OnLeftInputCallback += OnLeftInputCallback;
            InputHandler.OnRightInputCallback += OnRightInputCallback;
        }

        private void OnDisable()
        {
            InputHandler.OnLeftInputCallback -= OnLeftInputCallback;
            InputHandler.OnRightInputCallback -= OnRightInputCallback;
        }

        private void Start()
        {
            _sceneHandler = GameFactory.Get<SceneHandler>();
            _speed = movementSpeed;
        }

        private void OnLeftInputCallback() => transform.RotateAround(Vector3.zero, Vector3.forward, -1 * Time.deltaTime * _speed);

        private void OnRightInputCallback() => transform.RotateAround(Vector3.zero, Vector3.forward, 1 * Time.deltaTime * _speed);

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Hexagon"))
                return;
            _sceneHandler.GameOverScene();
        }
    }
}
