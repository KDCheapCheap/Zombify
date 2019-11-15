using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SoldierAbilitiesMenu : Menu
{
    public Image skill1, skill2, skill3, skill4;
    [SerializeField] private List<RectTransform> totalAbilties = new List<RectTransform>(); //Set in Inspector
    public RectTransform currentSelection;
    private RectTransform currentSelectedRect;
    bool isSelectionMoving = false;
    private List<RectTransform> rectsInDirection = new List<RectTransform>();

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        type = MenuType.LeftSidePanel;
        currentSelection.anchoredPosition = totalAbilties[0].anchoredPosition;
        currentSelectedRect = totalAbilties[0];
    }

    protected override void OnShow()
    {
        MenuManager.Instance.SidePanelOnShow(this, leftRightPanel);
    }

    private void Update()
    {
        if (isShowing)
        {
            if (InputManager.inputInstance.dPadDir != InputManager.DPadDirection.Null)
            {
                rectsInDirection = LocateRectsInDirection(InputManager.inputInstance.dPadDir, totalAbilties);
                RectTransform next = FindClosestRectInDirection(rectsInDirection, InputManager.inputInstance.dPadDir);
                currentSelectedRect = next;

                if (rectsInDirection.Count > 0 && !isSelectionMoving)
                {
                    StartCoroutine(MoveSelection(currentSelection, .1f, next));
                }
            }
        }
    }

    private IEnumerator MoveSelection(RectTransform current, float duration, RectTransform next)
    {
        float t = 0;
        isSelectionMoving = true;
        while (t < duration)
        {
            current.anchorMin = Vector2.Lerp(current.anchorMin, next.anchorMin, t);
            current.anchorMax = Vector2.Lerp(current.anchorMax, next.anchorMax, t);

            t += Time.deltaTime * duration;
            yield return null;
        }
        isSelectionMoving = false;
    }

    private RectTransform FindClosestRectInDirection(List<RectTransform> rects, InputManager.DPadDirection dir)
    {
        float closestDist = 10000;
        RectTransform closestRect = null;

        switch (InputManager.inputInstance.dPadDir)
        {
            case InputManager.DPadDirection.Up:
                foreach (RectTransform r in rects)
                {
                    float dist = Mathf.Abs(currentSelection.anchorMax.y - r.anchorMin.y);
                    if (dist < closestDist)
                    {
                        closestRect = r;
                    }
                }
                return closestRect;

            case InputManager.DPadDirection.Down:
                foreach (RectTransform r in rects)
                {
                    float dist = Mathf.Abs(currentSelection.anchorMin.y - r.anchorMax.y);
                    if (dist < closestDist)
                    {
                        closestRect = r;
                    }
                }
                return closestRect;

            case InputManager.DPadDirection.Left:
                foreach (RectTransform r in rects)
                {
                    float dist = Mathf.Abs(currentSelection.anchorMin.x - r.anchorMax.x);
                    if (dist < closestDist)
                    {
                        closestRect = r;
                    }
                }
                return closestRect;

            case InputManager.DPadDirection.Right:

                foreach (RectTransform r in rects)
                {
                    float dist = Mathf.Abs(currentSelection.anchorMax.x - r.anchorMin.x);
                    if (dist < closestDist)
                    {
                        closestRect = r;
                    }
                }
                return closestRect;

            default:
                return null;
        }



    }

    private List<RectTransform> LocateRectsInDirection(InputManager.DPadDirection dir, List<RectTransform> rects)
    {
        List<RectTransform> rectsInDir = new List<RectTransform>();
        switch (InputManager.inputInstance.dPadDir)
        {
            case InputManager.DPadDirection.Up:
                foreach (RectTransform r in rects)
                {
                    if (r == currentSelectedRect)
                    {
                        continue;
                    }
                    if (r.anchorMin.y > currentSelection.anchorMax.y)
                    {
                        rectsInDir.Add(r);
                    }
                }
                break;

            case InputManager.DPadDirection.Down:
                foreach (RectTransform r in rects)
                {
                    if (r == currentSelectedRect)
                    {
                        continue;
                    }
                    if (r.anchorMax.y < currentSelection.anchorMin.y)
                    {
                        rectsInDir.Add(r);
                    }
                }
                break;

            case InputManager.DPadDirection.Left:
                foreach (RectTransform r in rects)
                {
                    if (r == currentSelectedRect)
                    {
                        continue;
                    }

                    if (r.anchorMax.x > currentSelection.anchorMin.x)
                    {
                        rectsInDir.Add(r);
                    }
                }
                break;

            case InputManager.DPadDirection.Right:

                foreach (RectTransform r in rects)
                {
                    if (r == currentSelectedRect)
                    {
                        continue;
                    }
                    if (r.anchorMin.x > currentSelection.anchorMax.x)
                    {
                        rectsInDir.Add(r);
                    }
                }
                break;
        }
        return rectsInDir;
    }
}
