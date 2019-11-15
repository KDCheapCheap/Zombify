using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class Menu : MonoBehaviour
{
    public enum MenuType { RightSidePanel, LeftSidePanel, TopPanel, BottomPanel }
    [HideInInspector] public MenuType type;
    [HideInInspector]public bool inTransition;
    [HideInInspector] public bool isShowing;
    protected PlayerController player;
    [HideInInspector] public RectTransform rect;
    public RectTransform parentRect;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    public bool leftRightPanel
    {
        get
        {
            if(type == MenuType.RightSidePanel)
            {
                return true;
            }
            if(type == MenuType.LeftSidePanel)
            {
                return false;
            }

            return true;
        }
    }

    public bool topBottomPanel
    {
        get
        {
            if (type == MenuType.TopPanel)
            {
                return false;
            }
            if (type == MenuType.BottomPanel)
            {
                return true;
            }

            return true;
        }
    }

    protected virtual void OnShow()
    {
        
    }

    protected virtual void OnHide()
    {
        //if(!inTransition)
        //Any functionality once hidden goes here (set objects inactive etc etc)
    }
}
