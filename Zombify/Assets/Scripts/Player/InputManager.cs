using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager inputInstance;
    [HideInInspector] public PlayerControls controls; //control scheme
    public enum DPadDirection
    {
        Up, Down, Left, Right, Null
    }

    public DPadDirection dPadDir
    {
        get
        {
            if(dPadUp)
            {
                return DPadDirection.Up;
            }
            else if(dPadDown)
            {
                return DPadDirection.Down;
            }
            else if(dPadLeft)
            {
                return DPadDirection.Left;
            }
            else if(dPadRight)
            {
                return DPadDirection.Right;
            }
            else
            {
                return DPadDirection.Null;
            }
        }
    }

    #region Controls Vars

    [HideInInspector] public Vector2 movementVector;
    [HideInInspector] public Vector2 lookAtOffset;
    [HideInInspector] public Vector2 dPadValue;

    #region DPad
    public bool dPadRight
    {
        get
        {
            if (dPadValue.x > 0.1f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool dPadLeft
    {
        get
        {
            if (dPadValue.x < -0.1f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool dPadUp
    {
        get
        {
            if (dPadValue.y > 0.1f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool dPadDown
    {
        get
        {
            if (dPadValue.y < -0.1f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    #endregion

    #region Shoulder Buttons
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

    private float LBValue;
    public bool onLBPress
    {
        get
        { //        if xV == 1  true:else:false
            return LBValue == 1 ? true : false;
        }
    }
    #endregion

    #region Other
    private float backValue;
    public bool onBackPress
    {
        get
        {
            return backValue == 1 ? true : false;
        }
    }

    private float aValue;
    public bool onAPress
    {
        get
        {
            return aValue == 1 ? true : false;
        }

    }
    #endregion

    #endregion

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

        #region Lambda Setting

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

        controls.Gameplay.Ability.performed += ctx => LBValue = ctx.ReadValue<float>();
        controls.Gameplay.Ability.canceled += ctx => LBValue = 0;

        controls.Gameplay.AbilityMenu.performed += ctx => backValue = ctx.ReadValue<float>();
        controls.Gameplay.AbilityMenu.canceled += ctx => backValue = 0;

        controls.Gameplay.MenuMovement.performed += ctx => dPadValue = ctx.ReadValue<Vector2>();
        controls.Gameplay.MenuMovement.canceled += ctx => dPadValue = Vector2.zero;

        controls.Gameplay.MenuSelect.performed += ctx => aValue = ctx.ReadValue<float>();
        controls.Gameplay.MenuSelect.canceled += ctx => aValue = 0;

        #endregion
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
