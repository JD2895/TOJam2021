// GENERATED AUTOMATICALLY FROM 'Assets/PlayerMovement/BasicMoveset.inputactions'

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
                    ""id"": ""38c7f747-aaba-41b8-b6e5-2942c953643a"",
                    ""path"": ""<Keyboard>/space"",
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
            ""name"": ""Debug"",
            ""id"": ""d80ee12a-45ee-4afa-b04d-03855d408c4c"",
            ""actions"": [
                {
                    ""name"": ""ClearRecording"",
                    ""type"": ""Button"",
                    ""id"": ""cf87410c-23af-4483-b850-c25c96289a7e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StartRecording"",
                    ""type"": ""Button"",
                    ""id"": ""aceae024-4f86-43f9-8fe9-a94ae1c55c6c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StopRecording"",
                    ""type"": ""Button"",
                    ""id"": ""14eefeff-2af5-42a5-94f1-9f9eef03e001"",
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
                    ""name"": ""EndPlayback"",
                    ""type"": ""Button"",
                    ""id"": ""55b077d2-123c-4eb1-91e3-f1f0c47778c7"",
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
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayRecording"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5756712e-2b02-4518-8a7c-026fe8811a63"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EndPlayback"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd9ed7f2-aa28-4a6d-9e57-6a01e273414e"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StopRecording"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70965413-c3e5-4310-8891-cf8705c752a7"",
                    ""path"": ""<Keyboard>/backquote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ClearRecording"",
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
        // Debug
        m_Debug = asset.FindActionMap("Debug", throwIfNotFound: true);
        m_Debug_ClearRecording = m_Debug.FindAction("ClearRecording", throwIfNotFound: true);
        m_Debug_StartRecording = m_Debug.FindAction("StartRecording", throwIfNotFound: true);
        m_Debug_StopRecording = m_Debug.FindAction("StopRecording", throwIfNotFound: true);
        m_Debug_PlayRecording = m_Debug.FindAction("PlayRecording", throwIfNotFound: true);
        m_Debug_EndPlayback = m_Debug.FindAction("EndPlayback", throwIfNotFound: true);
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
    public struct BasicActions
    {
        private @BasicMoveset m_Wrapper;
        public BasicActions(@BasicMoveset wrapper) { m_Wrapper = wrapper; }
        public InputAction @Left => m_Wrapper.m_Basic_Left;
        public InputAction @Right => m_Wrapper.m_Basic_Right;
        public InputAction @Jump => m_Wrapper.m_Basic_Jump;
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
            }
        }
    }
    public BasicActions @Basic => new BasicActions(this);

    // Debug
    private readonly InputActionMap m_Debug;
    private IDebugActions m_DebugActionsCallbackInterface;
    private readonly InputAction m_Debug_ClearRecording;
    private readonly InputAction m_Debug_StartRecording;
    private readonly InputAction m_Debug_StopRecording;
    private readonly InputAction m_Debug_PlayRecording;
    private readonly InputAction m_Debug_EndPlayback;
    public struct DebugActions
    {
        private @BasicMoveset m_Wrapper;
        public DebugActions(@BasicMoveset wrapper) { m_Wrapper = wrapper; }
        public InputAction @ClearRecording => m_Wrapper.m_Debug_ClearRecording;
        public InputAction @StartRecording => m_Wrapper.m_Debug_StartRecording;
        public InputAction @StopRecording => m_Wrapper.m_Debug_StopRecording;
        public InputAction @PlayRecording => m_Wrapper.m_Debug_PlayRecording;
        public InputAction @EndPlayback => m_Wrapper.m_Debug_EndPlayback;
        public InputActionMap Get() { return m_Wrapper.m_Debug; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DebugActions set) { return set.Get(); }
        public void SetCallbacks(IDebugActions instance)
        {
            if (m_Wrapper.m_DebugActionsCallbackInterface != null)
            {
                @ClearRecording.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnClearRecording;
                @ClearRecording.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnClearRecording;
                @ClearRecording.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnClearRecording;
                @StartRecording.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnStartRecording;
                @StartRecording.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnStartRecording;
                @StartRecording.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnStartRecording;
                @StopRecording.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnStopRecording;
                @StopRecording.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnStopRecording;
                @StopRecording.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnStopRecording;
                @PlayRecording.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnPlayRecording;
                @PlayRecording.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnPlayRecording;
                @PlayRecording.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnPlayRecording;
                @EndPlayback.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnEndPlayback;
                @EndPlayback.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnEndPlayback;
                @EndPlayback.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnEndPlayback;
            }
            m_Wrapper.m_DebugActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ClearRecording.started += instance.OnClearRecording;
                @ClearRecording.performed += instance.OnClearRecording;
                @ClearRecording.canceled += instance.OnClearRecording;
                @StartRecording.started += instance.OnStartRecording;
                @StartRecording.performed += instance.OnStartRecording;
                @StartRecording.canceled += instance.OnStartRecording;
                @StopRecording.started += instance.OnStopRecording;
                @StopRecording.performed += instance.OnStopRecording;
                @StopRecording.canceled += instance.OnStopRecording;
                @PlayRecording.started += instance.OnPlayRecording;
                @PlayRecording.performed += instance.OnPlayRecording;
                @PlayRecording.canceled += instance.OnPlayRecording;
                @EndPlayback.started += instance.OnEndPlayback;
                @EndPlayback.performed += instance.OnEndPlayback;
                @EndPlayback.canceled += instance.OnEndPlayback;
            }
        }
    }
    public DebugActions @Debug => new DebugActions(this);
    public interface IBasicActions
    {
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IDebugActions
    {
        void OnClearRecording(InputAction.CallbackContext context);
        void OnStartRecording(InputAction.CallbackContext context);
        void OnStopRecording(InputAction.CallbackContext context);
        void OnPlayRecording(InputAction.CallbackContext context);
        void OnEndPlayback(InputAction.CallbackContext context);
    }
}
