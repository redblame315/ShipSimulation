//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/ShipControl.inputactions
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

public partial class @ShipControl : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ShipControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ShipControl"",
    ""maps"": [
        {
            ""name"": ""ShipController"",
            ""id"": ""2ae6c926-2693-4f92-aee5-a4e114f69189"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""ab25ccfb-a40a-41d6-8277-e22962919514"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Map"",
                    ""type"": ""Button"",
                    ""id"": ""910e4e73-d528-40f2-ad67-a572b5e46cfc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""EngineStart"",
                    ""type"": ""Button"",
                    ""id"": ""69326161-e775-411b-a480-638210666b74"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""EngeineStop"",
                    ""type"": ""Button"",
                    ""id"": ""b3151906-3c9b-45a7-9854-0db70d2cc305"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CameraAngle"",
                    ""type"": ""Button"",
                    ""id"": ""4bd6fa7f-a8fd-434d-b0af-10c9270009ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""41223585-7085-4154-a3f5-f3d0f3ea5895"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""9536f636-0d60-48cc-91bf-ef4941340c00"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""a452dcc9-c28d-45ac-8f19-60dcb4c4c044"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CameraView"",
                    ""type"": ""Value"",
                    ""id"": ""e7257913-6d8a-40ef-b512-172989b35855"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""a12de9d8-faff-4086-b654-865326d7d60f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Brake"",
                    ""type"": ""Button"",
                    ""id"": ""e2f14a35-f86a-43e9-9b67-52471e509941"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Backward"",
                    ""type"": ""Button"",
                    ""id"": ""44de675b-2498-402e-8dd6-dbf6e34a2209"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""870d628b-1d9a-4335-bd44-bf951ac6baed"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""814a1355-867a-4fb9-abdb-53dd4019073c"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Map"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e1ed1dc-16bb-44c9-bc07-f49b0ed42a58"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EngineStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f510bff-2006-435c-b8ce-5832cbdae3c1"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EngeineStop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""935fe966-3775-4461-aa1a-cae02f65ae07"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraAngle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac3a6c69-d19c-4f1b-8f96-272ca38678b2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51e9253e-787b-4c92-a8b4-60d0e0814a34"",
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
                    ""id"": ""cadc69d6-ac1d-4b7d-8216-1a497f0a31ad"",
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
                    ""id"": ""b5546712-340c-4933-8cc6-3b0ad61f375e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraView"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e69922f-3bc4-47f0-bf0d-dfe85924483f"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1f0cc16-62be-4826-af99-d6cd23cc23c3"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a8aedd6-f705-49b1-9f45-ea8c93d760d0"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ShipController
        m_ShipController = asset.FindActionMap("ShipController", throwIfNotFound: true);
        m_ShipController_Select = m_ShipController.FindAction("Select", throwIfNotFound: true);
        m_ShipController_Map = m_ShipController.FindAction("Map", throwIfNotFound: true);
        m_ShipController_EngineStart = m_ShipController.FindAction("EngineStart", throwIfNotFound: true);
        m_ShipController_EngeineStop = m_ShipController.FindAction("EngeineStop", throwIfNotFound: true);
        m_ShipController_CameraAngle = m_ShipController.FindAction("CameraAngle", throwIfNotFound: true);
        m_ShipController_Back = m_ShipController.FindAction("Back", throwIfNotFound: true);
        m_ShipController_Left = m_ShipController.FindAction("Left", throwIfNotFound: true);
        m_ShipController_Right = m_ShipController.FindAction("Right", throwIfNotFound: true);
        m_ShipController_CameraView = m_ShipController.FindAction("CameraView", throwIfNotFound: true);
        m_ShipController_Forward = m_ShipController.FindAction("Forward", throwIfNotFound: true);
        m_ShipController_Brake = m_ShipController.FindAction("Brake", throwIfNotFound: true);
        m_ShipController_Backward = m_ShipController.FindAction("Backward", throwIfNotFound: true);
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

    // ShipController
    private readonly InputActionMap m_ShipController;
    private IShipControllerActions m_ShipControllerActionsCallbackInterface;
    private readonly InputAction m_ShipController_Select;
    private readonly InputAction m_ShipController_Map;
    private readonly InputAction m_ShipController_EngineStart;
    private readonly InputAction m_ShipController_EngeineStop;
    private readonly InputAction m_ShipController_CameraAngle;
    private readonly InputAction m_ShipController_Back;
    private readonly InputAction m_ShipController_Left;
    private readonly InputAction m_ShipController_Right;
    private readonly InputAction m_ShipController_CameraView;
    private readonly InputAction m_ShipController_Forward;
    private readonly InputAction m_ShipController_Brake;
    private readonly InputAction m_ShipController_Backward;
    public struct ShipControllerActions
    {
        private @ShipControl m_Wrapper;
        public ShipControllerActions(@ShipControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_ShipController_Select;
        public InputAction @Map => m_Wrapper.m_ShipController_Map;
        public InputAction @EngineStart => m_Wrapper.m_ShipController_EngineStart;
        public InputAction @EngeineStop => m_Wrapper.m_ShipController_EngeineStop;
        public InputAction @CameraAngle => m_Wrapper.m_ShipController_CameraAngle;
        public InputAction @Back => m_Wrapper.m_ShipController_Back;
        public InputAction @Left => m_Wrapper.m_ShipController_Left;
        public InputAction @Right => m_Wrapper.m_ShipController_Right;
        public InputAction @CameraView => m_Wrapper.m_ShipController_CameraView;
        public InputAction @Forward => m_Wrapper.m_ShipController_Forward;
        public InputAction @Brake => m_Wrapper.m_ShipController_Brake;
        public InputAction @Backward => m_Wrapper.m_ShipController_Backward;
        public InputActionMap Get() { return m_Wrapper.m_ShipController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShipControllerActions set) { return set.Get(); }
        public void SetCallbacks(IShipControllerActions instance)
        {
            if (m_Wrapper.m_ShipControllerActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnSelect;
                @Map.started -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnMap;
                @Map.performed -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnMap;
                @Map.canceled -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnMap;
                @EngineStart.started -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnEngineStart;
                @EngineStart.performed -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnEngineStart;
                @EngineStart.canceled -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnEngineStart;
                @EngeineStop.started -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnEngeineStop;
                @EngeineStop.performed -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnEngeineStop;
                @EngeineStop.canceled -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnEngeineStop;
                @CameraAngle.started -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnCameraAngle;
                @CameraAngle.performed -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnCameraAngle;
                @CameraAngle.canceled -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnCameraAngle;
                @Back.started -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnBack;
                @Left.started -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnRight;
                @CameraView.started -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnCameraView;
                @CameraView.performed -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnCameraView;
                @CameraView.canceled -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnCameraView;
                @Forward.started -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnForward;
                @Brake.started -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnBrake;
                @Brake.performed -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnBrake;
                @Brake.canceled -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnBrake;
                @Backward.started -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnBackward;
                @Backward.performed -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnBackward;
                @Backward.canceled -= m_Wrapper.m_ShipControllerActionsCallbackInterface.OnBackward;
            }
            m_Wrapper.m_ShipControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Map.started += instance.OnMap;
                @Map.performed += instance.OnMap;
                @Map.canceled += instance.OnMap;
                @EngineStart.started += instance.OnEngineStart;
                @EngineStart.performed += instance.OnEngineStart;
                @EngineStart.canceled += instance.OnEngineStart;
                @EngeineStop.started += instance.OnEngeineStop;
                @EngeineStop.performed += instance.OnEngeineStop;
                @EngeineStop.canceled += instance.OnEngeineStop;
                @CameraAngle.started += instance.OnCameraAngle;
                @CameraAngle.performed += instance.OnCameraAngle;
                @CameraAngle.canceled += instance.OnCameraAngle;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @CameraView.started += instance.OnCameraView;
                @CameraView.performed += instance.OnCameraView;
                @CameraView.canceled += instance.OnCameraView;
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
                @Brake.started += instance.OnBrake;
                @Brake.performed += instance.OnBrake;
                @Brake.canceled += instance.OnBrake;
                @Backward.started += instance.OnBackward;
                @Backward.performed += instance.OnBackward;
                @Backward.canceled += instance.OnBackward;
            }
        }
    }
    public ShipControllerActions @ShipController => new ShipControllerActions(this);
    public interface IShipControllerActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnMap(InputAction.CallbackContext context);
        void OnEngineStart(InputAction.CallbackContext context);
        void OnEngeineStop(InputAction.CallbackContext context);
        void OnCameraAngle(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnCameraView(InputAction.CallbackContext context);
        void OnForward(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
        void OnBackward(InputAction.CallbackContext context);
    }
}
