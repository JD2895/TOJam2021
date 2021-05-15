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
    public struct BasicActions
    {
        private @BasicMoveset m_Wrapper;
        public BasicActions(@BasicMoveset wrapper) { m_Wrapper = wrapper; }
        public InputAction @Left => m_Wrapper.m_Basic_Left;
        public InputAction @Right => m_Wrapper.m_Basic_Right;
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
            }
        }
    }
    public BasicActions @Basic => new BasicActions(this);
    public interface IBasicActions
    {
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
    }
}
