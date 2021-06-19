// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerMovement/BasicMoveset.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @BasicMoveset : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @BasicMoveset()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""BasicMoveset"",
    ""maps"": [
        {
            ""name"": ""Basic"",
            ""id"": ""6273396c-699c-42ca-b2a7-b8058f323cb2"",
            ""actions"": [
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""de168fbc-d1c8-4427-9028-d6eb9f6b6f13"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""a4eb2107-74c2-45c1-801a-222b5cc57d08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""edf72d9a-3dd0-481c-835d-e2438d7494ed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash Left"",
                    ""type"": ""Button"",
                    ""id"": ""e3d2aca5-0a2c-45ff-9a6c-ecec7de76c53"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash Right"",
                    ""type"": ""Button"",
                    ""id"": ""5554893d-e922-4d5c-b2f1-e555ba87ac91"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Stunt"",
                    ""type"": ""Button"",
                    ""id"": ""d49324d4-af5a-4881-8450-f6d6229e38a4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8ce61f59-c823-410e-8fe8-8142ac50dcf2"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffee2888-b3fe-4cf1-8619-bc806c7d00fd"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""778b6f44-22d4-4cea-b827-a050279dc541"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc953efb-e421-439e-ba1f-25e5143cdc7c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e4e1774-16a0-46bd-bd1b-418b47e16c5b"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7cfe4072-73ec-4c5f-b669-036fd263c843"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b054004-9906-4075-bda1-ead71c1234ae"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7056a851-e567-4465-be9f-4038c516dee6"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62e5c666-c715-4dce-9675-4dc1df67d2ba"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46cf3b48-28d2-4108-83c9-c8a8095d7635"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a10be0f3-ecf1-4fa2-a496-8c70a31b5f2b"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stunt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5c73635-2983-45db-969e-20051daef155"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stunt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ed92893-ba28-42eb-bbe1-cb925e751236"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stunt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Debug"",
            ""id"": ""d80ee12a-45ee-4afa-b04d-03855d408c4c"",
            ""actions"": [
                {
                    ""name"": ""StartRecording"",
                    ""type"": ""Button"",
                    ""id"": ""aceae024-4f86-43f9-8fe9-a94ae1c55c6c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PlayRecording"",
                    ""type"": ""Button"",
                    ""id"": ""6b56d202-fe81-45cf-b9ef-840fee594fd7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""39a5e34c-dbba-4986-bff7-e03deca354fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4558a2ab-3cb8-4e8a-8a33-60e99170052e"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartRecording"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""080cb7a3-e969-49c9-baf1-1065cf325add"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayRecording"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""139d99e5-ead7-46e7-be65-deacb2dc783a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Basic
        m_Basic = asset.FindActionMap("Basic", throwIfNotFound: true);
        m_Basic_Left = m_Basic.FindAction("Left", throwIfNotFound: true);
        m_Basic_Right = m_Basic.FindAction("Right", throwIfNotFound: true);
        m_Basic_Jump = m_Basic.FindAction("Jump", throwIfNotFound: true);
        m_Basic_DashLeft = m_Basic.FindAction("Dash Left", throwIfNotFound: true);
        m_Basic_DashRight = m_Basic.FindAction("Dash Right", throwIfNotFound: true);
        m_Basic_Stunt = m_Basic.FindAction("Stunt", throwIfNotFound: true);
        // Debug
        m_Debug = asset.FindActionMap("Debug", throwIfNotFound: true);
        m_Debug_StartRecording = m_Debug.FindAction("StartRecording", throwIfNotFound: true);
        m_Debug_PlayRecording = m_Debug.FindAction("PlayRecording", throwIfNotFound: true);
        m_Debug_Menu = m_Debug.FindAction("Menu", throwIfNotFound: true);
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

    // Basic
    private readonly InputActionMap m_Basic;
    private IBasicActions m_BasicActionsCallbackInterface;
    private readonly InputAction m_Basic_Left;
    private readonly InputAction m_Basic_Right;
    private readonly InputAction m_Basic_Jump;
    private readonly InputAction m_Basic_DashLeft;
    private readonly InputAction m_Basic_DashRight;
    private readonly InputAction m_Basic_Stunt;
    public struct BasicActions
    {
        private @BasicMoveset m_Wrapper;
        public BasicActions(@BasicMoveset wrapper) { m_Wrapper = wrapper; }
        public InputAction @Left => m_Wrapper.m_Basic_Left;
        public InputAction @Right => m_Wrapper.m_Basic_Right;
        public InputAction @Jump => m_Wrapper.m_Basic_Jump;
        public InputAction @DashLeft => m_Wrapper.m_Basic_DashLeft;
        public InputAction @DashRight => m_Wrapper.m_Basic_DashRight;
        public InputAction @Stunt => m_Wrapper.m_Basic_Stunt;
        public InputActionMap Get() { return m_Wrapper.m_Basic; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BasicActions set) { return set.Get(); }
        public void SetCallbacks(IBasicActions instance)
        {
            if (m_Wrapper.m_BasicActionsCallbackInterface != null)
            {
                @Left.started -= m_Wrapper.m_BasicActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_BasicActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_BasicActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_BasicActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_BasicActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_BasicActionsCallbackInterface.OnRight;
                @Jump.started -= m_Wrapper.m_BasicActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_BasicActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_BasicActionsCallbackInterface.OnJump;
                @DashLeft.started -= m_Wrapper.m_BasicActionsCallbackInterface.OnDashLeft;
                @DashLeft.performed -= m_Wrapper.m_BasicActionsCallbackInterface.OnDashLeft;
                @DashLeft.canceled -= m_Wrapper.m_BasicActionsCallbackInterface.OnDashLeft;
                @DashRight.started -= m_Wrapper.m_BasicActionsCallbackInterface.OnDashRight;
                @DashRight.performed -= m_Wrapper.m_BasicActionsCallbackInterface.OnDashRight;
                @DashRight.canceled -= m_Wrapper.m_BasicActionsCallbackInterface.OnDashRight;
                @Stunt.started -= m_Wrapper.m_BasicActionsCallbackInterface.OnStunt;
                @Stunt.performed -= m_Wrapper.m_BasicActionsCallbackInterface.OnStunt;
                @Stunt.canceled -= m_Wrapper.m_BasicActionsCallbackInterface.OnStunt;
            }
            m_Wrapper.m_BasicActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @DashLeft.started += instance.OnDashLeft;
                @DashLeft.performed += instance.OnDashLeft;
                @DashLeft.canceled += instance.OnDashLeft;
                @DashRight.started += instance.OnDashRight;
                @DashRight.performed += instance.OnDashRight;
                @DashRight.canceled += instance.OnDashRight;
                @Stunt.started += instance.OnStunt;
                @Stunt.performed += instance.OnStunt;
                @Stunt.canceled += instance.OnStunt;
            }
        }
    }
    public BasicActions @Basic => new BasicActions(this);

    // Debug
    private readonly InputActionMap m_Debug;
    private IDebugActions m_DebugActionsCallbackInterface;
    private readonly InputAction m_Debug_StartRecording;
    private readonly InputAction m_Debug_PlayRecording;
    private readonly InputAction m_Debug_Menu;
    public struct DebugActions
    {
        private @BasicMoveset m_Wrapper;
        public DebugActions(@BasicMoveset wrapper) { m_Wrapper = wrapper; }
        public InputAction @StartRecording => m_Wrapper.m_Debug_StartRecording;
        public InputAction @PlayRecording => m_Wrapper.m_Debug_PlayRecording;
        public InputAction @Menu => m_Wrapper.m_Debug_Menu;
        public InputActionMap Get() { return m_Wrapper.m_Debug; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DebugActions set) { return set.Get(); }
        public void SetCallbacks(IDebugActions instance)
        {
            if (m_Wrapper.m_DebugActionsCallbackInterface != null)
            {
                @StartRecording.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnStartRecording;
                @StartRecording.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnStartRecording;
                @StartRecording.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnStartRecording;
                @PlayRecording.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnPlayRecording;
                @PlayRecording.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnPlayRecording;
                @PlayRecording.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnPlayRecording;
                @Menu.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnMenu;
            }
            m_Wrapper.m_DebugActionsCallbackInterface = instance;
            if (instance != null)
            {
                @StartRecording.started += instance.OnStartRecording;
                @StartRecording.performed += instance.OnStartRecording;
                @StartRecording.canceled += instance.OnStartRecording;
                @PlayRecording.started += instance.OnPlayRecording;
                @PlayRecording.performed += instance.OnPlayRecording;
                @PlayRecording.canceled += instance.OnPlayRecording;
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
            }
        }
    }
    public DebugActions @Debug => new DebugActions(this);
    public interface IBasicActions
    {
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDashLeft(InputAction.CallbackContext context);
        void OnDashRight(InputAction.CallbackContext context);
        void OnStunt(InputAction.CallbackContext context);
    }
    public interface IDebugActions
    {
        void OnStartRecording(InputAction.CallbackContext context);
        void OnPlayRecording(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
    }
}
