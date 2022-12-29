//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/InputControl/GameInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @GameInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""PlayerInput"",
            ""id"": ""6fcade0a-afd6-4c03-ab22-71142a224dd3"",
            ""actions"": [
                {
                    ""name"": ""KeyboardMovementAction"",
                    ""type"": ""Value"",
                    ""id"": ""302e3569-dc3c-4929-9dcf-825880be2978"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""TouchContact"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e83ea3a8-f7c1-4c55-90f2-eef062b2f8fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchMovementAction"",
                    ""type"": ""PassThrough"",
                    ""id"": ""989730d0-2879-4247-976d-fefde011196b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""8c371ea2-f097-4a38-9889-af9978839a81"",
                    ""path"": ""2DVector"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovementAction"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""00c65fb8-c673-4025-90f4-25ac235e5b92"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovementAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6f21e29f-c35a-4e96-a8f2-f37793848f40"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovementAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""303e75ff-43b8-427a-84a0-d2ef39f1229b"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e55f87d-8df6-47b2-95f3-d5675fb5f518"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchMovementAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Touchscreen"",
            ""bindingGroup"": ""Touchscreen"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerInput
        m_PlayerInput = asset.FindActionMap("PlayerInput", throwIfNotFound: true);
        m_PlayerInput_KeyboardMovementAction = m_PlayerInput.FindAction("KeyboardMovementAction", throwIfNotFound: true);
        m_PlayerInput_TouchContact = m_PlayerInput.FindAction("TouchContact", throwIfNotFound: true);
        m_PlayerInput_TouchMovementAction = m_PlayerInput.FindAction("TouchMovementAction", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerInput
    private readonly InputActionMap m_PlayerInput;
    private IPlayerInputActions m_PlayerInputActionsCallbackInterface;
    private readonly InputAction m_PlayerInput_KeyboardMovementAction;
    private readonly InputAction m_PlayerInput_TouchContact;
    private readonly InputAction m_PlayerInput_TouchMovementAction;
    public struct PlayerInputActions
    {
        private @GameInput m_Wrapper;
        public PlayerInputActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @KeyboardMovementAction => m_Wrapper.m_PlayerInput_KeyboardMovementAction;
        public InputAction @TouchContact => m_Wrapper.m_PlayerInput_TouchContact;
        public InputAction @TouchMovementAction => m_Wrapper.m_PlayerInput_TouchMovementAction;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInputActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerInputActions instance)
        {
            if (m_Wrapper.m_PlayerInputActionsCallbackInterface != null)
            {
                @KeyboardMovementAction.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnKeyboardMovementAction;
                @KeyboardMovementAction.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnKeyboardMovementAction;
                @KeyboardMovementAction.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnKeyboardMovementAction;
                @TouchContact.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnTouchContact;
                @TouchContact.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnTouchContact;
                @TouchContact.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnTouchContact;
                @TouchMovementAction.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnTouchMovementAction;
                @TouchMovementAction.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnTouchMovementAction;
                @TouchMovementAction.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnTouchMovementAction;
            }
            m_Wrapper.m_PlayerInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @KeyboardMovementAction.started += instance.OnKeyboardMovementAction;
                @KeyboardMovementAction.performed += instance.OnKeyboardMovementAction;
                @KeyboardMovementAction.canceled += instance.OnKeyboardMovementAction;
                @TouchContact.started += instance.OnTouchContact;
                @TouchContact.performed += instance.OnTouchContact;
                @TouchContact.canceled += instance.OnTouchContact;
                @TouchMovementAction.started += instance.OnTouchMovementAction;
                @TouchMovementAction.performed += instance.OnTouchMovementAction;
                @TouchMovementAction.canceled += instance.OnTouchMovementAction;
            }
        }
    }
    public PlayerInputActions @PlayerInput => new PlayerInputActions(this);
    private int m_TouchscreenSchemeIndex = -1;
    public InputControlScheme TouchscreenScheme
    {
        get
        {
            if (m_TouchscreenSchemeIndex == -1) m_TouchscreenSchemeIndex = asset.FindControlSchemeIndex("Touchscreen");
            return asset.controlSchemes[m_TouchscreenSchemeIndex];
        }
    }
    public interface IPlayerInputActions
    {
        void OnKeyboardMovementAction(InputAction.CallbackContext context);
        void OnTouchContact(InputAction.CallbackContext context);
        void OnTouchMovementAction(InputAction.CallbackContext context);
    }
}