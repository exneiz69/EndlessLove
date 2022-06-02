// GENERATED AUTOMATICALLY FROM 'Assets/Input System/Player Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""922b1339-7184-420e-a6cb-654ecde6b879"",
            ""actions"": [
                {
                    ""name"": ""DodgingDirection"",
                    ""type"": ""Value"",
                    ""id"": ""804d7643-e62b-4d51-8dcb-3afe8f8cdfe1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dodging"",
                    ""type"": ""Button"",
                    ""id"": ""9cdc2b48-c746-4cdd-8fd6-2750f4f0cfec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""182861ca-9ef3-45a3-9a25-cc5740c1202c"",
                    ""path"": ""<Touchscreen>/primaryTouch/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen"",
                    ""action"": ""DodgingDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff74e3af-55f7-434f-94e3-5045dc88627d"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen"",
                    ""action"": ""Dodging"",
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
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_DodgingDirection = m_Player.FindAction("DodgingDirection", throwIfNotFound: true);
        m_Player_Dodging = m_Player.FindAction("Dodging", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_DodgingDirection;
    private readonly InputAction m_Player_Dodging;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @DodgingDirection => m_Wrapper.m_Player_DodgingDirection;
        public InputAction @Dodging => m_Wrapper.m_Player_Dodging;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @DodgingDirection.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodgingDirection;
                @DodgingDirection.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodgingDirection;
                @DodgingDirection.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodgingDirection;
                @Dodging.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodging;
                @Dodging.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodging;
                @Dodging.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodging;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @DodgingDirection.started += instance.OnDodgingDirection;
                @DodgingDirection.performed += instance.OnDodgingDirection;
                @DodgingDirection.canceled += instance.OnDodgingDirection;
                @Dodging.started += instance.OnDodging;
                @Dodging.performed += instance.OnDodging;
                @Dodging.canceled += instance.OnDodging;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_TouchscreenSchemeIndex = -1;
    public InputControlScheme TouchscreenScheme
    {
        get
        {
            if (m_TouchscreenSchemeIndex == -1) m_TouchscreenSchemeIndex = asset.FindControlSchemeIndex("Touchscreen");
            return asset.controlSchemes[m_TouchscreenSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnDodgingDirection(InputAction.CallbackContext context);
        void OnDodging(InputAction.CallbackContext context);
    }
}
