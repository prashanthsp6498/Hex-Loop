using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Log = HexLoop.Core.Log;

namespace HexLoop
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private Camera cam;

        public static Action OnLeftInputCallback;
        public static Action OnRightInputCallback;

        private bool _keyboardInputStarted;
        private bool _touchInputStarted;
        private PointerEventData _eventData;
        private GameInput _gameInput;

        private void OnEnable()
        {
            _gameInput = new();
            _gameInput.Enable();
            ListenToInputAction();
        }

        private void OnDisable()
        {
            RemoveListenerFromInputAction();
            _gameInput?.Disable();
        }

        private void ListenToInputAction()
        {
            _gameInput.PlayerInput.KeyboardMovementAction.canceled += OnKeyboardInputCallbackCanceled;
            _gameInput.PlayerInput.KeyboardMovementAction.started += OnKeyboardInputCallbackStarted;

            _gameInput.PlayerInput.TouchContact.started += OnTouchContactActionStarted;
            _gameInput.PlayerInput.TouchContact.canceled += OnTouchContactActionPerformed;
        }
        private void RemoveListenerFromInputAction()
        {
            _gameInput.PlayerInput.TouchContact.started -= OnTouchContactActionStarted;
            _gameInput.PlayerInput.TouchContact.canceled -= OnTouchContactActionPerformed;
            _gameInput.PlayerInput.KeyboardMovementAction.canceled -= OnKeyboardInputCallbackCanceled;
            _gameInput.PlayerInput.KeyboardMovementAction.started -= OnKeyboardInputCallbackStarted;
        }

        private void OnTouchContactActionPerformed(InputAction.CallbackContext _) => _touchInputStarted = false;

        private void OnTouchContactActionStarted(InputAction.CallbackContext _) => _touchInputStarted = true;

        private void OnKeyboardInputCallbackStarted(InputAction.CallbackContext _) => _keyboardInputStarted = true;

        private void OnKeyboardInputCallbackCanceled(InputAction.CallbackContext _) => _keyboardInputStarted = false;

        private void OnKeyboardInput()
        {
            var pos = _gameInput.PlayerInput.KeyboardMovementAction.ReadValue<Vector2>();
            InputDecisionMaker(pos);
        }

        private void InputDecisionMaker(Vector2 inputValue)
        {
            if (inputValue.x > 0)
                OnRightInputCallback?.Invoke();
            else if (inputValue.x < 0)
                OnLeftInputCallback?.Invoke();
        }

        private void OnTouchInput()
        {
            var pos = _gameInput.PlayerInput.TouchMovementAction.ReadValue<Vector2>();
            pos = cam.ScreenToWorldPoint(new Vector3(pos.x, pos.y, cam.nearClipPlane));
            InputDecisionMaker(pos);
        }

        private void Update()
        {
            if (_keyboardInputStarted)
                OnKeyboardInput();

            if (_touchInputStarted)
                OnTouchInput();
        }
    }
}
