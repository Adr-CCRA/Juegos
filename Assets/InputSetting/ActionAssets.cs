//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/InputSetting/ActionAssets.inputactions
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

public partial class @ActionAssets : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ActionAssets()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ActionAssets"",
    ""maps"": [
        {
            ""name"": ""Personaje"",
            ""id"": ""e7d52d26-b3f8-4855-9785-9d3bc80742a1"",
            ""actions"": [
                {
                    ""name"": ""Mover"",
                    ""type"": ""Value"",
                    ""id"": ""676e4b36-5d0b-49cf-81e8-98db9e8a76aa"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Correr"",
                    ""type"": ""Button"",
                    ""id"": ""65cf4418-dc53-4dd0-9358-86f18c58e411"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Agarrar"",
                    ""type"": ""Button"",
                    ""id"": ""7ce413b2-81f2-4730-af6d-b79398c5c50a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Agacharce"",
                    ""type"": ""Button"",
                    ""id"": ""35de3213-0db9-42e1-a70d-c5b9f3431f6b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Mirar"",
                    ""type"": ""PassThrough"",
                    ""id"": ""358aa453-de21-4af3-9a8f-286fac24b978"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Camara"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a5aa326c-8b81-4419-bc9e-bcd5fd51649f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""442a344b-b4c1-46c1-bbd2-e5507abddc6d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""137d7673-c4fa-4e1b-9b1c-61f7c7ed706d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b2d4fe50-f105-4db9-9991-caec86d97f50"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8df090cc-222c-4fde-b16b-2de68615e15e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0110abbd-7dd2-4753-86d6-a18d634db6cd"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""67498486-75a2-4645-9059-654b2f8ad4d4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""teclasFlechas"",
                    ""id"": ""9f8f6900-b07e-46ca-a383-d73dc57cef06"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d9a42830-1238-4cea-a400-546fffdcc028"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8a0c1ac0-ff18-4574-ae2e-f869a545762e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c7d88276-fe49-432e-9afb-3bdacce5b71b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b95c0ad6-7f5c-4073-b69a-f9b5213d87e9"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2d30421d-8bca-432a-bed2-ed91b3dc0553"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Correr"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6611a620-0a9a-4aa8-a7b8-96ef1e02cc52"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Agarrar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5e29002-bb08-46e1-bde9-4bc37f53f09c"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Agacharce"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""173e406d-e090-472a-82e9-af40dfb21d91"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mirar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e18d484-2b98-41be-b9c2-0f3807830bc1"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mirar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d44a19df-8bc4-4060-9ad2-83e5e509c598"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camara"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Right Stick"",
                    ""id"": ""678a4f95-13be-4dcc-b78c-136cc9174d20"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camara"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fe897065-c60b-4d66-b207-1f2fbbffef11"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camara"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8f26910d-8395-4ecd-999a-0e248cd614d2"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camara"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5d1a68a2-8dfb-43b1-bac8-732e3a70cb11"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camara"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e4a16e2c-0f45-4782-b383-de0af0c3cfc2"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camara"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Personaje
        m_Personaje = asset.FindActionMap("Personaje", throwIfNotFound: true);
        m_Personaje_Mover = m_Personaje.FindAction("Mover", throwIfNotFound: true);
        m_Personaje_Correr = m_Personaje.FindAction("Correr", throwIfNotFound: true);
        m_Personaje_Agarrar = m_Personaje.FindAction("Agarrar", throwIfNotFound: true);
        m_Personaje_Agacharce = m_Personaje.FindAction("Agacharce", throwIfNotFound: true);
        m_Personaje_Mirar = m_Personaje.FindAction("Mirar", throwIfNotFound: true);
        m_Personaje_Camara = m_Personaje.FindAction("Camara", throwIfNotFound: true);
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

    // Personaje
    private readonly InputActionMap m_Personaje;
    private IPersonajeActions m_PersonajeActionsCallbackInterface;
    private readonly InputAction m_Personaje_Mover;
    private readonly InputAction m_Personaje_Correr;
    private readonly InputAction m_Personaje_Agarrar;
    private readonly InputAction m_Personaje_Agacharce;
    private readonly InputAction m_Personaje_Mirar;
    private readonly InputAction m_Personaje_Camara;
    public struct PersonajeActions
    {
        private @ActionAssets m_Wrapper;
        public PersonajeActions(@ActionAssets wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mover => m_Wrapper.m_Personaje_Mover;
        public InputAction @Correr => m_Wrapper.m_Personaje_Correr;
        public InputAction @Agarrar => m_Wrapper.m_Personaje_Agarrar;
        public InputAction @Agacharce => m_Wrapper.m_Personaje_Agacharce;
        public InputAction @Mirar => m_Wrapper.m_Personaje_Mirar;
        public InputAction @Camara => m_Wrapper.m_Personaje_Camara;
        public InputActionMap Get() { return m_Wrapper.m_Personaje; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PersonajeActions set) { return set.Get(); }
        public void SetCallbacks(IPersonajeActions instance)
        {
            if (m_Wrapper.m_PersonajeActionsCallbackInterface != null)
            {
                @Mover.started -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnMover;
                @Mover.performed -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnMover;
                @Mover.canceled -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnMover;
                @Correr.started -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnCorrer;
                @Correr.performed -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnCorrer;
                @Correr.canceled -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnCorrer;
                @Agarrar.started -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnAgarrar;
                @Agarrar.performed -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnAgarrar;
                @Agarrar.canceled -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnAgarrar;
                @Agacharce.started -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnAgacharce;
                @Agacharce.performed -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnAgacharce;
                @Agacharce.canceled -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnAgacharce;
                @Mirar.started -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnMirar;
                @Mirar.performed -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnMirar;
                @Mirar.canceled -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnMirar;
                @Camara.started -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnCamara;
                @Camara.performed -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnCamara;
                @Camara.canceled -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnCamara;
            }
            m_Wrapper.m_PersonajeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Mover.started += instance.OnMover;
                @Mover.performed += instance.OnMover;
                @Mover.canceled += instance.OnMover;
                @Correr.started += instance.OnCorrer;
                @Correr.performed += instance.OnCorrer;
                @Correr.canceled += instance.OnCorrer;
                @Agarrar.started += instance.OnAgarrar;
                @Agarrar.performed += instance.OnAgarrar;
                @Agarrar.canceled += instance.OnAgarrar;
                @Agacharce.started += instance.OnAgacharce;
                @Agacharce.performed += instance.OnAgacharce;
                @Agacharce.canceled += instance.OnAgacharce;
                @Mirar.started += instance.OnMirar;
                @Mirar.performed += instance.OnMirar;
                @Mirar.canceled += instance.OnMirar;
                @Camara.started += instance.OnCamara;
                @Camara.performed += instance.OnCamara;
                @Camara.canceled += instance.OnCamara;
            }
        }
    }
    public PersonajeActions @Personaje => new PersonajeActions(this);
    public interface IPersonajeActions
    {
        void OnMover(InputAction.CallbackContext context);
        void OnCorrer(InputAction.CallbackContext context);
        void OnAgarrar(InputAction.CallbackContext context);
        void OnAgacharce(InputAction.CallbackContext context);
        void OnMirar(InputAction.CallbackContext context);
        void OnCamara(InputAction.CallbackContext context);
    }
}
