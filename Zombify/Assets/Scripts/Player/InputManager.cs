//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Rewired;

//public class InputManager : MonoBehaviour
//{
//    public static InputManager inputInstance;
//    [SerializeField] private int playerID = 0;
//    [SerializeField]
////    public Player soldier
////    {
////        get
////        {
////            return ReInput.players.GetPlayer(0);
////        }
////    }

////    [SerializeField] public Player engineer
////    {
////        get
////        {
////            return ReInput.players.GetPlayer(1);
////        }
////    }
////    [SerializeField] public Player medic
////    {
////        get
////        {
////            return ReInput.players.GetPlayer(2);
////        }
////    }
////    [SerializeField] public Player scout
////    {
////        get
////        {
////            return ReInput.players.GetPlayer(3);
////        }
////    }

////    public enum DPadDirection
////    {
////        Up, Down, Left, Right, Null
////    }

////    public DPadDirection dPadDir
////    {
////        get
////        {
////            if(dPadUp)
////            {
////                return DPadDirection.Up;
////            }
////            else if(dPadDown)
////            {
////                return DPadDirection.Down;
////            }
////            else if(dPadLeft)
////            {
////                return DPadDirection.Left;
////            }
////            else if(dPadRight)
////            {
////                return DPadDirection.Right;
////            }
////            else
////            {
////                return DPadDirection.Null;
////            }
////        }
////    }

////    #region Controls Vars

////    [HideInInspector] public Vector2 movementVector
////    {
////        get
////        {
////            return new Vector2(GetPlayer().GetAxis("Move Horizontal"), GetPlayer().GetAxis("Move Vertical"));
////        }
////    }
////    [HideInInspector] public Vector2 lookAtOffset
////    {
////        get
////        {
////            return new Vector2(GetPlayer().GetAxis("Look Horizontal"), GetPlayer().GetAxis("Look Vertical"));
////        }
////    }

////    #region DPad
////    public bool dPadRight
////    {
////        get
////        {
////            return GetPlayer().GetButtonDown("Menu Right");
////        }
////    }

////    public bool dPadLeft
////    {
////        get
////        {
////            return GetPlayer().GetButtonDown("Menu Left");
////        }
////    }

////    public bool dPadUp
////    {
////        get
////        {
////            return GetPlayer().GetButtonDown("Menu Up");
////        }
////    }

////    public bool dPadDown
////    {
////        get
////        {
////            return GetPlayer().GetButtonDown("Menu Down");
////        }
////    }
////    #endregion

////    #region Shoulder Buttons
////    private float RTValue;
////    public bool isRTPressed
////    {
////        get
////        {
////            return GetPlayer().GetAxis("Shoot") >= .8f ? true : false;
////        }
////    }

////    private float LTValue;
////    public bool isLTPressed
////    {
////        get
////        {
////            return GetPlayer().GetAxis("Sprint") >= .3f ? true : false;
////        }
////    }

////    private float RBValue;
////    public bool onRBPressed
////    {
////        get
////        {
////            return GetPlayer().GetButtonDown("Reload");
////        }
////    }

////    private float LBValue;
////    public bool onLBPress
////    {
////        get
////        { //        if xV == 1  true:else:false
////            return GetPlayer().GetButtonDown("Use Ability");
////        }
////    }
////    #endregion

////    #region Other
////    private float backValue;
////    public bool onBackPress
////    {
////        get
////        {
////            return GetPlayer().GetButtonDown("Open Menu");
////        }
////    }

////    private float aValue;
////    public bool onAPress
////    {
////        get
////        {
////            return GetPlayer().GetButtonDown("Menu Select");
////        }

////    }
////    #endregion

////    #endregion

////    private void Awake()
////    {
////        if (inputInstance == null)
////        {
////            inputInstance = this;
////        }
////        else
////        {
////            Destroy(gameObject);
////        }
////    }

////    public Player GetPlayer()
////    {
////        if(ReInput.controllers.GetLastActiveController() == soldier.controllers.GetLastActiveController())
////        {
////            return soldier;
////        }
////        if (ReInput.controllers.GetLastActiveController() == engineer.controllers.GetLastActiveController())
////        {
////            return engineer;
////        }
////        if (ReInput.controllers.GetLastActiveController() == medic.controllers.GetLastActiveController())
////        {
////            return medic;
////        }
////        if (ReInput.controllers.GetLastActiveController() == scout.controllers.GetLastActiveController())
////        {
////            return scout;
////        }
////        else
////        {
////            return null;
////        }
////    }
////}
