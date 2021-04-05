using HexLoop.Manager;
using UnityEngine;

namespace HexLoop.GamePlay
{
    public class Player : MonoBehaviour
    {
        #region serializedVariables
        [SerializeField] private float movementSpeed = 500f;
        private SceneHandler sceneHandler;
        #endregion


        #region privateVariables
        private float movementManager;
        private float movement = 0f;
        private float speed = 0f;
        private Vector3 touchPosition = Vector3.zero;
        #endregion


        private void Start()
        {
            sceneHandler = FindObjectOfType<SceneHandler>();
            speed = movementSpeed;
        }

        void Update()
        {
            TouchInputData();
            movement = touchPosition.x;
            movementManager = (int)(-movement * Time.deltaTime * speed);
            transform.RotateAround(Vector3.zero, Vector3.forward, movementManager);
            TouchInputData();

        }

        private void TouchInputData()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    if (touchPosition.x < -1.9 || touchPosition.x > 1.9)
                    {
                        speed = movementSpeed - (movementSpeed / 2 );
                        Debug.Log(speed);
                        Debug.Log(touchPosition);
                    }
                    Debug.Log(touch.type);
                }
            }
            else
                touchPosition = Vector3.zero;
        }

        private void OnTriggerEnter2D(Collider2D other) => sceneHandler.GameOverScene();
    }
}
