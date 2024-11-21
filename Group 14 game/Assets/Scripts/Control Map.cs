//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Control Map.inputactions
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

public partial class @Controls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Control Map"",
    ""maps"": [
        {
            ""name"": ""Player1Controls"",
            ""id"": ""fbb3e62b-19df-4c02-9e22-fc9df365d0f6"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""93898093-a26b-4492-85cd-3b983f25baa4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""9f583534-3c33-4668-ae2d-26da432dea18"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""6749a819-72c6-44d0-9bbf-f2a329c49b0f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""bd2f496a-ef0d-4fe1-b64e-d9f3df9845de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""c0af096f-5204-4163-bb54-575e9a039dac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""35ff0709-5dc1-4b9b-8dda-124e53090cb8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6f399b77-ca58-439e-98f5-57e7e39892f0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""18eab294-b6c6-49c3-b4d5-16b00f44f178"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1e974d9f-3381-4d7f-9032-d5ef287d0592"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""414d013f-20ee-4a03-b630-0d2392234f56"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""329e1bd3-bed2-4d4e-8cd9-274c9527a169"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09aba779-6f66-4c6c-bfd6-9a033e677cfd"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ec2a4d0-e3c7-49cf-a3e1-c3fb3616292c"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0cea93fa-0f88-4b93-9b33-ede5a2eecd4b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52851677-dc46-45aa-819f-b6d7fa87395c"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player2Controls"",
            ""id"": ""7ade40f4-dbfd-4d01-a9c0-3839f8e52350"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""bda56c07-2b89-4abe-a210-89b1448eaa27"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""74954e78-5286-44f6-a61b-546c3849afd0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""3258a286-57fa-43d4-a807-c7db73049cf1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""724cf53d-5185-478e-91e7-d43340bf2ff0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""ae2a2dfb-30fd-4ff2-ab49-61aec5a737de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""df0fe952-371f-42c0-82e9-18700e351a17"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c0162ce3-b968-4b10-a36d-ead9e6ed584a"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""dd67b36c-ed57-4cef-8184-1059508f5e94"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f96bd0f7-3272-4f22-97e6-f843723e3173"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8f955468-8c6f-4527-b1cc-76bcfa494879"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c8e37b66-db1d-4986-b669-171f56e246b7"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63bff1ce-5d3d-429d-9fad-13b401794b39"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""697243c8-8e77-426e-a453-6e405b6cb9da"",
                    ""path"": ""<Keyboard>/slash"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee7ca249-52d9-4ffa-aef4-38589d1adbb3"",
                    ""path"": ""<Keyboard>/backslash"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player3Controls"",
            ""id"": ""3dc914c8-d314-40ce-bbb3-d2550649f309"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""b31610c3-4204-4430-9519-167786144d49"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""2b8f0f57-09fd-49d1-bfe9-b060ce06310b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""e550aa68-7c42-480c-bea7-b7f6bb6691ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""46d7b1f5-112f-439a-aa76-21705a6a0d3e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""015fd740-6b51-441f-a719-3520d335cfe4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""22625b49-6f9a-49ae-b994-9a603e3df815"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""232ca535-b031-47bc-b119-eba09111d52c"",
                    ""path"": ""<WebGLGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3913cd13-a418-4159-b739-8400eaa7884c"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2df00c08-99f9-438c-aade-543b8ce67305"",
                    ""path"": ""<WebGLGamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61c9e886-bf78-46d7-b7c5-8197a9007107"",
                    ""path"": ""<DualShockGamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9772a29-1b61-4b26-b3bd-464370c17857"",
                    ""path"": ""<WebGLGamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce4e93df-3e74-4bc8-939e-ee2304a5c2f3"",
                    ""path"": ""<WebGLGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""22f4ce48-f29e-4150-a47b-822598d1ad94"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f11b0dd9-5d4c-4cbb-b9aa-461c80ce5fe3"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fae03a62-843b-4366-8a8f-b10c859ca311"",
                    ""path"": ""<WebGLGamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player1Controls
        m_Player1Controls = asset.FindActionMap("Player1Controls", throwIfNotFound: true);
        m_Player1Controls_Movement = m_Player1Controls.FindAction("Movement", throwIfNotFound: true);
        m_Player1Controls_Interact = m_Player1Controls.FindAction("Interact", throwIfNotFound: true);
        m_Player1Controls_Attack = m_Player1Controls.FindAction("Attack", throwIfNotFound: true);
        m_Player1Controls_Jump = m_Player1Controls.FindAction("Jump", throwIfNotFound: true);
        m_Player1Controls_Dash = m_Player1Controls.FindAction("Dash", throwIfNotFound: true);
        // Player2Controls
        m_Player2Controls = asset.FindActionMap("Player2Controls", throwIfNotFound: true);
        m_Player2Controls_Movement = m_Player2Controls.FindAction("Movement", throwIfNotFound: true);
        m_Player2Controls_Interact = m_Player2Controls.FindAction("Interact", throwIfNotFound: true);
        m_Player2Controls_Attack = m_Player2Controls.FindAction("Attack", throwIfNotFound: true);
        m_Player2Controls_Jump = m_Player2Controls.FindAction("Jump", throwIfNotFound: true);
        m_Player2Controls_Dash = m_Player2Controls.FindAction("Dash", throwIfNotFound: true);
        // Player3Controls
        m_Player3Controls = asset.FindActionMap("Player3Controls", throwIfNotFound: true);
        m_Player3Controls_Movement = m_Player3Controls.FindAction("Movement", throwIfNotFound: true);
        m_Player3Controls_Interact = m_Player3Controls.FindAction("Interact", throwIfNotFound: true);
        m_Player3Controls_Attack = m_Player3Controls.FindAction("Attack", throwIfNotFound: true);
        m_Player3Controls_Jump = m_Player3Controls.FindAction("Jump", throwIfNotFound: true);
        m_Player3Controls_Dash = m_Player3Controls.FindAction("Dash", throwIfNotFound: true);
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

    // Player1Controls
    private readonly InputActionMap m_Player1Controls;
    private List<IPlayer1ControlsActions> m_Player1ControlsActionsCallbackInterfaces = new List<IPlayer1ControlsActions>();
    private readonly InputAction m_Player1Controls_Movement;
    private readonly InputAction m_Player1Controls_Interact;
    private readonly InputAction m_Player1Controls_Attack;
    private readonly InputAction m_Player1Controls_Jump;
    private readonly InputAction m_Player1Controls_Dash;
    public struct Player1ControlsActions
    {
        private @Controls m_Wrapper;
        public Player1ControlsActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player1Controls_Movement;
        public InputAction @Interact => m_Wrapper.m_Player1Controls_Interact;
        public InputAction @Attack => m_Wrapper.m_Player1Controls_Attack;
        public InputAction @Jump => m_Wrapper.m_Player1Controls_Jump;
        public InputAction @Dash => m_Wrapper.m_Player1Controls_Dash;
        public InputActionMap Get() { return m_Wrapper.m_Player1Controls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1ControlsActions set) { return set.Get(); }
        public void AddCallbacks(IPlayer1ControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_Player1ControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_Player1ControlsActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Dash.started += instance.OnDash;
            @Dash.performed += instance.OnDash;
            @Dash.canceled += instance.OnDash;
        }

        private void UnregisterCallbacks(IPlayer1ControlsActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Dash.started -= instance.OnDash;
            @Dash.performed -= instance.OnDash;
            @Dash.canceled -= instance.OnDash;
        }

        public void RemoveCallbacks(IPlayer1ControlsActions instance)
        {
            if (m_Wrapper.m_Player1ControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayer1ControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_Player1ControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_Player1ControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public Player1ControlsActions @Player1Controls => new Player1ControlsActions(this);

    // Player2Controls
    private readonly InputActionMap m_Player2Controls;
    private List<IPlayer2ControlsActions> m_Player2ControlsActionsCallbackInterfaces = new List<IPlayer2ControlsActions>();
    private readonly InputAction m_Player2Controls_Movement;
    private readonly InputAction m_Player2Controls_Interact;
    private readonly InputAction m_Player2Controls_Attack;
    private readonly InputAction m_Player2Controls_Jump;
    private readonly InputAction m_Player2Controls_Dash;
    public struct Player2ControlsActions
    {
        private @Controls m_Wrapper;
        public Player2ControlsActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player2Controls_Movement;
        public InputAction @Interact => m_Wrapper.m_Player2Controls_Interact;
        public InputAction @Attack => m_Wrapper.m_Player2Controls_Attack;
        public InputAction @Jump => m_Wrapper.m_Player2Controls_Jump;
        public InputAction @Dash => m_Wrapper.m_Player2Controls_Dash;
        public InputActionMap Get() { return m_Wrapper.m_Player2Controls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player2ControlsActions set) { return set.Get(); }
        public void AddCallbacks(IPlayer2ControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_Player2ControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_Player2ControlsActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Dash.started += instance.OnDash;
            @Dash.performed += instance.OnDash;
            @Dash.canceled += instance.OnDash;
        }

        private void UnregisterCallbacks(IPlayer2ControlsActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Dash.started -= instance.OnDash;
            @Dash.performed -= instance.OnDash;
            @Dash.canceled -= instance.OnDash;
        }

        public void RemoveCallbacks(IPlayer2ControlsActions instance)
        {
            if (m_Wrapper.m_Player2ControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayer2ControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_Player2ControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_Player2ControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public Player2ControlsActions @Player2Controls => new Player2ControlsActions(this);

    // Player3Controls
    private readonly InputActionMap m_Player3Controls;
    private List<IPlayer3ControlsActions> m_Player3ControlsActionsCallbackInterfaces = new List<IPlayer3ControlsActions>();
    private readonly InputAction m_Player3Controls_Movement;
    private readonly InputAction m_Player3Controls_Interact;
    private readonly InputAction m_Player3Controls_Attack;
    private readonly InputAction m_Player3Controls_Jump;
    private readonly InputAction m_Player3Controls_Dash;
    public struct Player3ControlsActions
    {
        private @Controls m_Wrapper;
        public Player3ControlsActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player3Controls_Movement;
        public InputAction @Interact => m_Wrapper.m_Player3Controls_Interact;
        public InputAction @Attack => m_Wrapper.m_Player3Controls_Attack;
        public InputAction @Jump => m_Wrapper.m_Player3Controls_Jump;
        public InputAction @Dash => m_Wrapper.m_Player3Controls_Dash;
        public InputActionMap Get() { return m_Wrapper.m_Player3Controls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player3ControlsActions set) { return set.Get(); }
        public void AddCallbacks(IPlayer3ControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_Player3ControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_Player3ControlsActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Dash.started += instance.OnDash;
            @Dash.performed += instance.OnDash;
            @Dash.canceled += instance.OnDash;
        }

        private void UnregisterCallbacks(IPlayer3ControlsActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Dash.started -= instance.OnDash;
            @Dash.performed -= instance.OnDash;
            @Dash.canceled -= instance.OnDash;
        }

        public void RemoveCallbacks(IPlayer3ControlsActions instance)
        {
            if (m_Wrapper.m_Player3ControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayer3ControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_Player3ControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_Player3ControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public Player3ControlsActions @Player3Controls => new Player3ControlsActions(this);
    public interface IPlayer1ControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
    public interface IPlayer2ControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
    public interface IPlayer3ControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
}
