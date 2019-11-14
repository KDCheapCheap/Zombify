using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    #region Menu References
    public Menu soldierAbilitiesMenu;
    #endregion
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Show(Menu menu)
    {
        switch (menu.type)
        {
            case Menu.MenuType.RightSidePanel:
                SidePanelOnShow(menu, true);
                break;
            case Menu.MenuType.BottomPanel:
                TopBottomPanelOnShow(menu, true);
                break;
            case Menu.MenuType.LeftSidePanel:
                SidePanelOnShow(menu, false);
                break;
            case Menu.MenuType.TopPanel:
                TopBottomPanelOnShow(menu, false);
                break;
        }
    }

    //false = left, true = right
    public void SidePanelOnShow(Menu menu, bool rightLeft)
    {
        //holds transition logic
        if (rightLeft)
        {

        }
        else
        {
            menu.rect.Translate(Vector3.right * (menu.parentRect.sizeDelta.x / 2) * Time.deltaTime);
        }
    }

    //false = top, true = bottom
    public void TopBottomPanelOnShow(Menu menu, bool topBottom)
    {
        //holds transition logic
    }

    public void SidePanelHide(Menu menu, bool righLeft)
    {
        //holds transition logic
    }

    public void TopBottomHide(Menu menu, bool topBottom)
    {
        //holds transition logic
    }
}
