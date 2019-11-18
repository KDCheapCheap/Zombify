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
        if (!menu.isShowing)
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
    }

    public void Hide(Menu menu)
    {
        switch (menu.type)
        {
            case Menu.MenuType.RightSidePanel:
                SidePanelHide(menu, true);
                break;
            case Menu.MenuType.BottomPanel:
                TopBottomHide(menu, true);
                break;
            case Menu.MenuType.LeftSidePanel:
                SidePanelHide(menu, false);
                break;
            case Menu.MenuType.TopPanel:
                TopBottomHide(menu, false);
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
            Debug.Log("Should move panel");
            StartCoroutine(ShowSidePanel(menu, .5f));
        }
    }

    //false = top, true = bottom
    public void TopBottomPanelOnShow(Menu menu, bool topBottom)
    {
        //holds transition logic
        if(topBottom)
        {
            StartCoroutine(ShowBottomPanel(menu, .5f));
        }
        else
        {
            //Do top
        }
    }

    public void SidePanelHide(Menu menu, bool rightLeft)
    {
        if (!menu.inTransition)
        {
            //holds transition logic
            if (rightLeft)
            {

            }
            else
            {
                Debug.Log("Should move panel");
                StartCoroutine(HideSidePanel(menu, .5f));
            }
        }
    }

    public void TopBottomHide(Menu menu, bool topBottom)
    {
        if(topBottom)
        {
            StartCoroutine(HideBottomPanel(menu, .5f));
        }
        else
        {
            //Do top
        }
        //holds transition logic
    }

    private IEnumerator ShowSidePanel(Menu menu, float duration)
    {
        menu.inTransition = true;
        float t = 0;
        Vector2 maxEndPos = new Vector2(1f, menu.rect.anchorMax.y);
        Vector2 minEndPos = new Vector2(0.5f, menu.rect.anchorMin.y);

        while (t < duration)
        {
            //Lerp max anchor to 1 and min anchor to 0.5
            menu.rect.anchorMin = Vector2.Lerp(menu.rect.anchorMin, minEndPos, t);
            menu.rect.anchorMax = Vector2.Lerp(menu.rect.anchorMax, maxEndPos, t);
            t += Time.deltaTime;
            yield return null;
        }

        if (t >= duration)
        {
            menu.inTransition = false;
            menu.isShowing = true;
        }
    }

    private IEnumerator HideSidePanel(Menu menu, float duration)
    {
        menu.inTransition = true;
        float t = 0;
        Vector2 maxEndPos = new Vector2(0.5f, menu.rect.anchorMax.y);
        Vector2 minEndPos = new Vector2(0f, menu.rect.anchorMin.y);

        while(t < duration)
        {
            menu.rect.anchorMin = Vector2.Lerp(menu.rect.anchorMin, minEndPos, t);
            menu.rect.anchorMax = Vector2.Lerp(menu.rect.anchorMax, maxEndPos, t);
            t += Time.deltaTime;
            yield return null;
        }

        if (t >= duration)
        {
            menu.inTransition = false;
            menu.isShowing = false;
        }
    }

    private IEnumerator ShowBottomPanel(Menu menu, float duration)
    {
        menu.inTransition = true;
        float t = 0;

        Vector2 maxEndPos = new Vector2(menu.rect.anchorMax.x, 1);
        Vector2 minEndPos = new Vector2(menu.rect.anchorMin.x, 0.5f);

        while (t < duration)
        {
            //Lerp max anchor to 1 and min anchor to 0.5
            menu.rect.anchorMin = Vector2.Lerp(menu.rect.anchorMin, minEndPos, t);
            menu.rect.anchorMax = Vector2.Lerp(menu.rect.anchorMax, maxEndPos, t);
            t += Time.deltaTime;
            yield return null;
        }

        if (t >= duration)
        {
            menu.inTransition = false;
            menu.isShowing = true;
        }
    }

    private IEnumerator HideBottomPanel(Menu menu, float duration)
    {
        menu.inTransition = true;
        float t = 0;

        Vector2 maxEndPos = new Vector2(menu.rect.anchorMax.x, 0.5f);
        Vector2 minEndPos = new Vector2(menu.rect.anchorMin.x, 0);

        while (t < duration)
        {
            //Lerp max anchor to 1 and min anchor to 0.5
            menu.rect.anchorMin = Vector2.Lerp(menu.rect.anchorMin, minEndPos, t);
            menu.rect.anchorMax = Vector2.Lerp(menu.rect.anchorMax, maxEndPos, t);
            t += Time.deltaTime;
            yield return null;
        }

        if (t >= duration)
        {
            menu.inTransition = false;
            menu.isShowing = false;
        }
    }
}
