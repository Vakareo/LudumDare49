// GENERATED AUTOMATICALLY FROM 'Assets/MyInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MyInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MyInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MyInputs"",
    ""maps"": [
        {
            ""name"": ""Base"",
            ""id"": ""ac36af09-0e0c-4c73-a86e-c4b73bb18af8"",
            ""actions"": [
                {
                    ""name"": ""Vertical"",
                    ""type"": ""Value"",
                    ""id"": ""2dd6fc2c-9b67-44cf-b832-a3d6db89a5b3"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""Value"",
                    ""id"": ""d1856153-aa0b-4a86-9644-e5d23b3320b8"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Throttle"",
                    ""type"": ""Value"",
                    ""id"": ""5b85340d-d96a-49c1-9a7a-693519409157"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Brake"",
                    ""type"": ""Value"",
                    ""id"": ""ac17a38b-1ffb-457f-ad19-47263477252b"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pitch"",
                    ""type"": ""Button"",
                    ""id"": ""1e282be8-7eab-4b30-8fce-2419e7e524c7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleGlide"",
                    ""type"": ""Button"",
                    ""id"": ""2a6ef121-d33b-45d5-bc20-9fc566d83cd6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""ce21d129-a8da-4850-ac7a-0b0076d81fb9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""63aa835f-f593-419b-9258-a49561808929"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ced7cbf8-945f-4a9f-b097-0f6ebb75e39b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""4953c823-2f0f-4d3a-a23b-c4a5c668b5a3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""858852ac-e851-4fc9-ad9d-377fd49d1dcb"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ccb7a14b-b36f-4f43-ad1d-6041d50d4115"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""a6f66ed6-fcde-4ad3-8800-82b04b4c5427"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d598bbe5-a8fc-4764-a5b3-7c96ff304a5c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0360f824-2ab6-4c21-9a21-d9c381f6d454"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""834f455c-4251-40c0-972c-087a9af5af99"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3d6f80b1-b9c1-4d44-9ce5-f8b8e5abd6a7"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8ae9fb9e-d16a-487d-afde-694a0033b8b8"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e5cb6e87-2938-4388-a587-232f440fac58"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae455f80-3f0b-4217-ade5-b4a74d673a2d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a7257bf-46cb-4e14-88ac-4e63ee45ac04"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0be5522f-bb7d-4e74-ab9c-2c1567ed9b17"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""1054ecd5-5a11-4d83-b426-7f60af8f3780"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pitch"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b5ab0f3e-cda1-454d-8f83-850d8ce7c2b3"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""728543ac-ad80-4f4d-8fa5-c643bac7546b"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2baf08d8-9a34-4f08-ac09-4325a87f5816"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleGlide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47e65b7e-d3ee-42c0-b7fe-f348876ded64"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleGlide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Base
        m_Base = asset.FindActionMap("Base", throwIfNotFound: true);
        m_Base_Vertical = m_Base.FindAction("Vertical", throwIfNotFound: true);
        m_Base_Horizontal = m_Base.FindAction("Horizontal", throwIfNotFound: true);
        m_Base_Throttle = m_Base.FindAction("Throttle", throwIfNotFound: true);
        m_Base_Brake = m_Base.FindAction("Brake", throwIfNotFound: true);
        m_Base_Pitch = m_Base.FindAction("Pitch", throwIfNotFound: true);
        m_Base_ToggleGlide = m_Base.FindAction("ToggleGlide", throwIfNotFound: true);
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

    // Base
    private readonly InputActionMap m_Base;
    private IBaseActions m_BaseActionsCallbackInterface;
    private readonly InputAction m_Base_Vertical;
    private readonly InputAction m_Base_Horizontal;
    private readonly InputAction m_Base_Throttle;
    private readonly InputAction m_Base_Brake;
    private readonly InputAction m_Base_Pitch;
    private readonly InputAction m_Base_ToggleGlide;
    public struct BaseActions
    {
        private @MyInputs m_Wrapper;
        public BaseActions(@MyInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Vertical => m_Wrapper.m_Base_Vertical;
        public InputAction @Horizontal => m_Wrapper.m_Base_Horizontal;
        public InputAction @Throttle => m_Wrapper.m_Base_Throttle;
        public InputAction @Brake => m_Wrapper.m_Base_Brake;
        public InputAction @Pitch => m_Wrapper.m_Base_Pitch;
        public InputAction @ToggleGlide => m_Wrapper.m_Base_ToggleGlide;
        public InputActionMap Get() { return m_Wrapper.m_Base; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BaseActions set) { return set.Get(); }
        public void SetCallbacks(IBaseActions instance)
        {
            if (m_Wrapper.m_BaseActionsCallbackInterface != null)
            {
                @Vertical.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnVertical;
                @Vertical.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnVertical;
                @Vertical.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnVertical;
                @Horizontal.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnHorizontal;
                @Horizontal.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnHorizontal;
                @Horizontal.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnHorizontal;
                @Throttle.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnThrottle;
                @Throttle.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnThrottle;
                @Throttle.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnThrottle;
                @Brake.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnBrake;
                @Brake.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnBrake;
                @Brake.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnBrake;
                @Pitch.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnPitch;
                @Pitch.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnPitch;
                @Pitch.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnPitch;
                @ToggleGlide.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnToggleGlide;
                @ToggleGlide.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnToggleGlide;
                @ToggleGlide.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnToggleGlide;
            }
            m_Wrapper.m_BaseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Vertical.started += instance.OnVertical;
                @Vertical.performed += instance.OnVertical;
                @Vertical.canceled += instance.OnVertical;
                @Horizontal.started += instance.OnHorizontal;
                @Horizontal.performed += instance.OnHorizontal;
                @Horizontal.canceled += instance.OnHorizontal;
                @Throttle.started += instance.OnThrottle;
                @Throttle.performed += instance.OnThrottle;
                @Throttle.canceled += instance.OnThrottle;
                @Brake.started += instance.OnBrake;
                @Brake.performed += instance.OnBrake;
                @Brake.canceled += instance.OnBrake;
                @Pitch.started += instance.OnPitch;
                @Pitch.performed += instance.OnPitch;
                @Pitch.canceled += instance.OnPitch;
                @ToggleGlide.started += instance.OnToggleGlide;
                @ToggleGlide.performed += instance.OnToggleGlide;
                @ToggleGlide.canceled += instance.OnToggleGlide;
            }
        }
    }
    public BaseActions @Base => new BaseActions(this);
    public interface IBaseActions
    {
        void OnVertical(InputAction.CallbackContext context);
        void OnHorizontal(InputAction.CallbackContext context);
        void OnThrottle(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
        void OnPitch(InputAction.CallbackContext context);
        void OnToggleGlide(InputAction.CallbackContext context);
    }
}
