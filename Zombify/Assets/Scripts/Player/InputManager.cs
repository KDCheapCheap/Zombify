using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager inputInstance;
    [HideInInspector] public PlayerControls controls; //control scheme

    [HideInInspector] public Vector2 movementVector;
    [HideInInspector] public Vector2 lookAtOffset;

    private float RTValue;
    public bool isRTPressed
    {
        get
        {
            return RTValue >= .8f ? true : false;
        }
    }

    private float LTValue;
    public bool isLTPressed
    {
        get
        {
            return LTValue >= .3f ? true : false;
        }
    }

    private float RBValue;
    public bool onRBPressed
    {
        get
        {
            return RBValue == 1 ? true : false;
        }
    }

    private float xValue;
    public bool onXPress
    {
        get
        { //        if xV == 1  true:else:false
            return xValue == 1 ? true : false;
        }
    }

    private void Awake()
    {
        if (inputInstance == null)
        {
            inputInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        controls = new PlayerControls();

        controls.Gameplay.Move.performed += ctx => movementVector = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => movementVector = Vector2.zero;

        controls.Gameplay.Look.performed += ctx => lookAtOffset = ctx.ReadValue<Vector2>();
        controls.Gameplay.Look.canceled += ctx => lookAtOffset = Vector2.zero;

        controls.Gameplay.Shoot.performed += ctx => RTValue = ctx.ReadValue<float>();
        controls.Gameplay.Shoot.canceled += ctx => RTValue = 0;

        controls.Gameplay.Sprint.performed += ctx => LTValue = ctx.ReadValue<float>();
        controls.Gameplay.Sprint.canceled += ctx => LTValue = 0;

        controls.Gameplay.Reload.performed += ctx => RBValue = ctx.ReadValue<float>();
        controls.Gameplay.Reload.canceled += ctx => RBValue = 0;

        controls.Gameplay.Ability.performed += ctx => xValue = ctx.ReadValue<float>();
        controls.Gameplay.Ability.canceled += ctx => xValue = 0;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
