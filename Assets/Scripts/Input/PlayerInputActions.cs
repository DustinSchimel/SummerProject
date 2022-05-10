//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/Input/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""38d585b3-ff7e-4733-9bc8-6e7793a49e23"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""355a7b51-eefb-49d9-9ee8-5c80424ad1c0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""1923d5e1-fc7f-4d6b-b704-775bae1ad5f1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3aaccf5b-5278-492e-853f-f55a2c9d25ce"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7468228c-d357-42cf-b598-ac411ef737ad"",
                    ""path"": ""<SwitchProControllerHID>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""99098dbd-a9d6-438e-8dc9-ff6247ca2d00"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07d520fb-158f-416d-8556-4e63942a032b"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""0420cfdb-f102-4a59-a04a-4b1030a40d63"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b2e52bdc-7ce9-4e6e-b671-b01aa7343eb6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""322318e5-d569-4c6c-b185-dcc9c887738b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""483e1655-39bf-421b-92bf-50a62f8b83f9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""950ca1da-2677-4b7b-9dcd-a9b3b3457815"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b941de27-72fe-4302-95cd-8e8fc0135d5a"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b34c0874-6266-4531-bfa6-4927697ed03d"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""36bc0a8f-ce30-4683-b7cf-8c50298e59a1"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""TitleScreen"",
            ""id"": ""2b5b6935-3803-49fc-a7b3-81e664dfc891"",
            ""actions"": [
                {
                    ""name"": ""MoveUp"",
                    ""type"": ""Button"",
                    ""id"": ""97b95106-a2eb-4e19-b6d2-5346e8bc6701"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveDown"",
                    ""type"": ""Button"",
                    ""id"": ""067d1b1d-ada7-4c5a-a859-8b9ca83fe3f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectOption"",
                    ""type"": ""Button"",
                    ""id"": ""b561e3a0-ab45-4084-8a94-b18c8f030297"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dcfaa3c8-15ed-4b78-9c01-499473b56d9c"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""905af897-ecd0-41bd-be36-93ba3de958ca"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3fce76d9-7e4d-4f23-b976-4d764a644eb4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae67b4cd-13ec-4eca-be89-bc8e80be56a0"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b47eb75f-02ea-4f0c-bd71-c9efda588ba9"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1b044ed-2018-49f7-bfac-3732cc06e191"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7223e4bc-8953-462b-9bd0-2ee6e22d63ef"",
                    ""path"": ""<SwitchProControllerHID>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""SelectOption"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""246e72e9-5877-4ff3-831f-47a468dff7e7"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""SelectOption"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7f20937-efd9-41ae-a609-0b83ed1ae837"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""SelectOption"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1c6eed3-160f-401c-9e0b-d2a918cb2d43"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectOption"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""OptionsScreen"",
            ""id"": ""b757576b-daa7-4551-9fbd-1eb4dc8f8e35"",
            ""actions"": [
                {
                    ""name"": ""MoveUp"",
                    ""type"": ""Button"",
                    ""id"": ""5ed72039-b2af-4473-ac6c-95b1d3f62bf3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveDown"",
                    ""type"": ""Button"",
                    ""id"": ""ec62da63-4fc8-4bd8-bc9f-43947359d851"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectOption"",
                    ""type"": ""Button"",
                    ""id"": ""0a5e531d-089f-4aba-b52c-7260d0683203"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""VolumeUp"",
                    ""type"": ""Button"",
                    ""id"": ""3b111fce-df1d-4514-a01a-ce7a0c15aa1d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""VolumeDown"",
                    ""type"": ""Button"",
                    ""id"": ""07356ab6-0bbe-4220-b695-dc9b17a44b3b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6f8b5f80-cae4-439c-9968-2460850a5f1f"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71c002db-bc20-490a-9011-f62bbff7b58c"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34e914c9-f906-4dea-9b51-3c60d3d5ee30"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""43119a5f-aa36-4c60-9e14-bb545d5151bb"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d646427-8651-4020-b63f-ef13f1b62534"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c846d74-3370-4ae7-909e-beb94b50abbb"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5e535ba-ea70-4039-a8f4-c9f5525f0e0f"",
                    ""path"": ""<SwitchProControllerHID>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""SelectOption"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2bb02dbb-d865-42bd-9d23-57bf17512db9"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""SelectOption"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59975e13-ec53-4350-9071-0c591fa3cd3a"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""SelectOption"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ddd642bc-18a7-4dad-bccb-a22d62a4aa20"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectOption"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41f46bd5-9969-4757-92b6-1e7f91be28bb"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""VolumeUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""983c67c0-3ed7-4b32-90b5-8ded8cbaed63"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""VolumeUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""972c783d-ed8c-4acb-8c76-01f6e96dddac"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""VolumeUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90487829-08a2-4e88-8446-2dd4fc47fa6a"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""VolumeDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b96769df-3935-4946-81d3-e87145088654"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""VolumeDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d522de1-2d79-4ad1-b7d6-a217fea3debd"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""VolumeDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PauseMenu"",
            ""id"": ""3d6b9c82-3db2-4046-b9a8-6adba1c3fb0a"",
            ""actions"": [],
            ""bindings"": []
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        // TitleScreen
        m_TitleScreen = asset.FindActionMap("TitleScreen", throwIfNotFound: true);
        m_TitleScreen_MoveUp = m_TitleScreen.FindAction("MoveUp", throwIfNotFound: true);
        m_TitleScreen_MoveDown = m_TitleScreen.FindAction("MoveDown", throwIfNotFound: true);
        m_TitleScreen_SelectOption = m_TitleScreen.FindAction("SelectOption", throwIfNotFound: true);
        // OptionsScreen
        m_OptionsScreen = asset.FindActionMap("OptionsScreen", throwIfNotFound: true);
        m_OptionsScreen_MoveUp = m_OptionsScreen.FindAction("MoveUp", throwIfNotFound: true);
        m_OptionsScreen_MoveDown = m_OptionsScreen.FindAction("MoveDown", throwIfNotFound: true);
        m_OptionsScreen_SelectOption = m_OptionsScreen.FindAction("SelectOption", throwIfNotFound: true);
        m_OptionsScreen_VolumeUp = m_OptionsScreen.FindAction("VolumeUp", throwIfNotFound: true);
        m_OptionsScreen_VolumeDown = m_OptionsScreen.FindAction("VolumeDown", throwIfNotFound: true);
        // PauseMenu
        m_PauseMenu = asset.FindActionMap("PauseMenu", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Movement;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // TitleScreen
    private readonly InputActionMap m_TitleScreen;
    private ITitleScreenActions m_TitleScreenActionsCallbackInterface;
    private readonly InputAction m_TitleScreen_MoveUp;
    private readonly InputAction m_TitleScreen_MoveDown;
    private readonly InputAction m_TitleScreen_SelectOption;
    public struct TitleScreenActions
    {
        private @PlayerInputActions m_Wrapper;
        public TitleScreenActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveUp => m_Wrapper.m_TitleScreen_MoveUp;
        public InputAction @MoveDown => m_Wrapper.m_TitleScreen_MoveDown;
        public InputAction @SelectOption => m_Wrapper.m_TitleScreen_SelectOption;
        public InputActionMap Get() { return m_Wrapper.m_TitleScreen; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TitleScreenActions set) { return set.Get(); }
        public void SetCallbacks(ITitleScreenActions instance)
        {
            if (m_Wrapper.m_TitleScreenActionsCallbackInterface != null)
            {
                @MoveUp.started -= m_Wrapper.m_TitleScreenActionsCallbackInterface.OnMoveUp;
                @MoveUp.performed -= m_Wrapper.m_TitleScreenActionsCallbackInterface.OnMoveUp;
                @MoveUp.canceled -= m_Wrapper.m_TitleScreenActionsCallbackInterface.OnMoveUp;
                @MoveDown.started -= m_Wrapper.m_TitleScreenActionsCallbackInterface.OnMoveDown;
                @MoveDown.performed -= m_Wrapper.m_TitleScreenActionsCallbackInterface.OnMoveDown;
                @MoveDown.canceled -= m_Wrapper.m_TitleScreenActionsCallbackInterface.OnMoveDown;
                @SelectOption.started -= m_Wrapper.m_TitleScreenActionsCallbackInterface.OnSelectOption;
                @SelectOption.performed -= m_Wrapper.m_TitleScreenActionsCallbackInterface.OnSelectOption;
                @SelectOption.canceled -= m_Wrapper.m_TitleScreenActionsCallbackInterface.OnSelectOption;
            }
            m_Wrapper.m_TitleScreenActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveUp.started += instance.OnMoveUp;
                @MoveUp.performed += instance.OnMoveUp;
                @MoveUp.canceled += instance.OnMoveUp;
                @MoveDown.started += instance.OnMoveDown;
                @MoveDown.performed += instance.OnMoveDown;
                @MoveDown.canceled += instance.OnMoveDown;
                @SelectOption.started += instance.OnSelectOption;
                @SelectOption.performed += instance.OnSelectOption;
                @SelectOption.canceled += instance.OnSelectOption;
            }
        }
    }
    public TitleScreenActions @TitleScreen => new TitleScreenActions(this);

    // OptionsScreen
    private readonly InputActionMap m_OptionsScreen;
    private IOptionsScreenActions m_OptionsScreenActionsCallbackInterface;
    private readonly InputAction m_OptionsScreen_MoveUp;
    private readonly InputAction m_OptionsScreen_MoveDown;
    private readonly InputAction m_OptionsScreen_SelectOption;
    private readonly InputAction m_OptionsScreen_VolumeUp;
    private readonly InputAction m_OptionsScreen_VolumeDown;
    public struct OptionsScreenActions
    {
        private @PlayerInputActions m_Wrapper;
        public OptionsScreenActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveUp => m_Wrapper.m_OptionsScreen_MoveUp;
        public InputAction @MoveDown => m_Wrapper.m_OptionsScreen_MoveDown;
        public InputAction @SelectOption => m_Wrapper.m_OptionsScreen_SelectOption;
        public InputAction @VolumeUp => m_Wrapper.m_OptionsScreen_VolumeUp;
        public InputAction @VolumeDown => m_Wrapper.m_OptionsScreen_VolumeDown;
        public InputActionMap Get() { return m_Wrapper.m_OptionsScreen; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(OptionsScreenActions set) { return set.Get(); }
        public void SetCallbacks(IOptionsScreenActions instance)
        {
            if (m_Wrapper.m_OptionsScreenActionsCallbackInterface != null)
            {
                @MoveUp.started -= m_Wrapper.m_OptionsScreenActionsCallbackInterface.OnMoveUp;
                @MoveUp.performed -= m_Wrapper.m_OptionsScreenActionsCallbackInterface.OnMoveUp;
                @MoveUp.canceled -= m_Wrapper.m_OptionsScreenActionsCallbackInterface.OnMoveUp;
                @MoveDown.started -= m_Wrapper.m_OptionsScreenActionsCallbackInterface.OnMoveDown;
                @MoveDown.performed -= m_Wrapper.m_OptionsScreenActionsCallbackInterface.OnMoveDown;
                @MoveDown.canceled -= m_Wrapper.m_OptionsScreenActionsCallbackInterface.OnMoveDown;
                @SelectOption.started -= m_Wrapper.m_OptionsScreenActionsCallbackInterface.OnSelectOption;
                @SelectOption.performed -= m_Wrapper.m_OptionsScreenActionsCallbackInterface.OnSelectOption;
                @SelectOption.canceled -= m_Wrapper.m_OptionsScreenActionsCallbackInterface.OnSelectOption;
                @VolumeUp.started -= m_Wrapper.m_OptionsScreenActionsCallbackInterface.OnVolumeUp;
                @VolumeUp.performed -= m_Wrapper.m_OptionsScreenActionsCallbackInterface.OnVolumeUp;
                @VolumeUp.canceled -= m_Wrapper.m_OptionsScreenActionsCallbackInterface.OnVolumeUp;
                @VolumeDown.started -= m_Wrapper.m_OptionsScreenActionsCallbackInterface.OnVolumeDown;
                @VolumeDown.performed -= m_Wrapper.m_OptionsScreenActionsCallbackInterface.OnVolumeDown;
                @VolumeDown.canceled -= m_Wrapper.m_OptionsScreenActionsCallbackInterface.OnVolumeDown;
            }
            m_Wrapper.m_OptionsScreenActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveUp.started += instance.OnMoveUp;
                @MoveUp.performed += instance.OnMoveUp;
                @MoveUp.canceled += instance.OnMoveUp;
                @MoveDown.started += instance.OnMoveDown;
                @MoveDown.performed += instance.OnMoveDown;
                @MoveDown.canceled += instance.OnMoveDown;
                @SelectOption.started += instance.OnSelectOption;
                @SelectOption.performed += instance.OnSelectOption;
                @SelectOption.canceled += instance.OnSelectOption;
                @VolumeUp.started += instance.OnVolumeUp;
                @VolumeUp.performed += instance.OnVolumeUp;
                @VolumeUp.canceled += instance.OnVolumeUp;
                @VolumeDown.started += instance.OnVolumeDown;
                @VolumeDown.performed += instance.OnVolumeDown;
                @VolumeDown.canceled += instance.OnVolumeDown;
            }
        }
    }
    public OptionsScreenActions @OptionsScreen => new OptionsScreenActions(this);

    // PauseMenu
    private readonly InputActionMap m_PauseMenu;
    private IPauseMenuActions m_PauseMenuActionsCallbackInterface;
    public struct PauseMenuActions
    {
        private @PlayerInputActions m_Wrapper;
        public PauseMenuActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputActionMap Get() { return m_Wrapper.m_PauseMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseMenuActions set) { return set.Get(); }
        public void SetCallbacks(IPauseMenuActions instance)
        {
            if (m_Wrapper.m_PauseMenuActionsCallbackInterface != null)
            {
            }
            m_Wrapper.m_PauseMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
            }
        }
    }
    public PauseMenuActions @PauseMenu => new PauseMenuActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
    }
    public interface ITitleScreenActions
    {
        void OnMoveUp(InputAction.CallbackContext context);
        void OnMoveDown(InputAction.CallbackContext context);
        void OnSelectOption(InputAction.CallbackContext context);
    }
    public interface IOptionsScreenActions
    {
        void OnMoveUp(InputAction.CallbackContext context);
        void OnMoveDown(InputAction.CallbackContext context);
        void OnSelectOption(InputAction.CallbackContext context);
        void OnVolumeUp(InputAction.CallbackContext context);
        void OnVolumeDown(InputAction.CallbackContext context);
    }
    public interface IPauseMenuActions
    {
    }
}
