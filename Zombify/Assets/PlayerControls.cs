// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerControls : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""506b3174-c7ba-41ea-addb-eed1cd07751f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""143bce47-634a-429d-b90e-d3067dbd3e6e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""fdc00625-6d2c-4f30-b739-4c84f8c34b2d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""a02440ce-f04d-4204-b57a-f6c07c7947e8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""a20039e5-da5c-4037-a206-b50c9d453959"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability"",
                    ""type"": ""Button"",
                    ""id"": ""b5d6e3fa-c35b-47bc-816c-44269174f609"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""e3399c80-effc-41de-94a1-0d817182af93"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AbilityMenu"",
                    ""type"": ""Button"",
                    ""id"": ""8e56983c-d1c3-411c-8314-7b1aad385c90"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""69e88665-1552-4267-b7d9-a832283a08d6"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""d4a552be-37d6-4c9b-96eb-b1293f45dda5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9a1f22bd-5a50-497f-aae2-09fbb58ddc6b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e96ead98-cf0a-4806-a88a-5c05794b16a9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""aab94a1e-c7bf-4b2d-b82e-f56e46701dc9"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""37d18d30-d100-405d-9f35-a4dd2ab9aac4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0dc303f6-7a8d-4c6c-941c-58cfc441773d"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0eb8fec-6aa0-492f-b836-b79cabec0539"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3cce75d-8f3e-428d-94a8-0bea79a8f8f9"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""456945f0-fa90-46a9-b0bb-15c3065b894d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1767e662-fc2f-49ce-af02-994ae6968965"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c63c050-a3af-4188-a855-a53895b05a46"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""247dc8f0-e066-4d12-8990-4d118264d574"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be9ce087-2f9d-4e07-8109-3da66802d034"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1659bb8-e87f-490d-9770-c3fa808ccaa0"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a12a3085-3ba4-4041-8fb5-d72b4e6dcced"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8072fffc-d964-476a-9ab7-b5fe379743da"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AbilityMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""8e4f036b-214a-4423-a14a-ea1774b971f0"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""82aa2116-18bf-4356-bab9-359b61837dd8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7bebd750-3566-497e-941c-c022ed199492"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Look = m_Gameplay.FindAction("Look", throwIfNotFound: true);
        m_Gameplay_Shoot = m_Gameplay.FindAction("Shoot", throwIfNotFound: true);
        m_Gameplay_Reload = m_Gameplay.FindAction("Reload", throwIfNotFound: true);
        m_Gameplay_Ability = m_Gameplay.FindAction("Ability", throwIfNotFound: true);
        m_Gameplay_Sprint = m_Gameplay.FindAction("Sprint", throwIfNotFound: true);
        m_Gameplay_AbilityMenu = m_Gameplay.FindAction("AbilityMenu", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Newaction = m_Menu.FindAction("New action", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Look;
    private readonly InputAction m_Gameplay_Shoot;
    private readonly InputAction m_Gameplay_Reload;
    private readonly InputAction m_Gameplay_Ability;
    private readonly InputAction m_Gameplay_Sprint;
    private readonly InputAction m_Gameplay_AbilityMenu;
    public struct GameplayActions
    {
        private PlayerControls m_Wrapper;
        public GameplayActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Look => m_Wrapper.m_Gameplay_Look;
        public InputAction @Shoot => m_Wrapper.m_Gameplay_Shoot;
        public InputAction @Reload => m_Wrapper.m_Gameplay_Reload;
        public InputAction @Ability => m_Wrapper.m_Gameplay_Ability;
        public InputAction @Sprint => m_Wrapper.m_Gameplay_Sprint;
        public InputAction @AbilityMenu => m_Wrapper.m_Gameplay_AbilityMenu;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                Look.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                Look.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                Look.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                Shoot.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                Shoot.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                Shoot.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                Reload.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReload;
                Reload.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReload;
                Reload.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReload;
                Ability.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbility;
                Ability.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbility;
                Ability.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbility;
                Sprint.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                Sprint.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                Sprint.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                AbilityMenu.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbilityMenu;
                AbilityMenu.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbilityMenu;
                AbilityMenu.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbilityMenu;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
                Look.started += instance.OnLook;
                Look.performed += instance.OnLook;
                Look.canceled += instance.OnLook;
                Shoot.started += instance.OnShoot;
                Shoot.performed += instance.OnShoot;
                Shoot.canceled += instance.OnShoot;
                Reload.started += instance.OnReload;
                Reload.performed += instance.OnReload;
                Reload.canceled += instance.OnReload;
                Ability.started += instance.OnAbility;
                Ability.performed += instance.OnAbility;
                Ability.canceled += instance.OnAbility;
                Sprint.started += instance.OnSprint;
                Sprint.performed += instance.OnSprint;
                Sprint.canceled += instance.OnSprint;
                AbilityMenu.started += instance.OnAbilityMenu;
                AbilityMenu.performed += instance.OnAbilityMenu;
                AbilityMenu.canceled += instance.OnAbilityMenu;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Newaction;
    public struct MenuActions
    {
        private PlayerControls m_Wrapper;
        public MenuActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Menu_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                Newaction.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnNewaction;
                Newaction.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnNewaction;
                Newaction.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                Newaction.started += instance.OnNewaction;
                Newaction.performed += instance.OnNewaction;
                Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnAbility(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnAbilityMenu(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
