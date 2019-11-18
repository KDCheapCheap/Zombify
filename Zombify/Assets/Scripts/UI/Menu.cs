﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class Menu : MonoBehaviour
{
    public enum MenuType { RightSidePanel, LeftSidePanel, TopPanel, BottomPanel }

    [HideInInspector] public MenuType type;
    [HideInInspector] public bool inTransition;
    [HideInInspector] public bool isShowing;
    protected PlayerController player;
    [HideInInspector] public RectTransform rect;
    public RectTransform parentRect;
    public RectTransform currentSelection;
    bool isSelectionMoving = false;
    private List<RectTransform> rectsInDirection = new List<RectTransform>();
    [SerializeField] protected List<RectTransform> totalAbilties = new List<RectTransform>(); //Set in Inspector - Must match order of character ability list

    protected RectTransform currentSelectedRect;
    protected Ability currentSelectedAbility;
    protected Ability currentEquippedAbility;
    protected string abilityName;

    public int abilityID; //SET IN INSPECTOR - based on the skilltree of whatever player the ability is for

    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    public bool leftRightPanel
    {
        get
        {
            if (type == MenuType.RightSidePanel)
            {
                return true;
            }
            if (type == MenuType.LeftSidePanel)
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
    protected virtual void Update()
    {
    }

    protected void UpdateSelection(PlayerController player)
    {
        if (isShowing)
        {
            if (player.dPadDir != PlayerController.DPadDirection.Null)
            {
                rectsInDirection = LocateRectsInDirection(player, totalAbilties);
                RectTransform next = FindClosestRectInDirection(rectsInDirection, player.dPadDir);


                if (rectsInDirection.Count > 0 && !isSelectionMoving)
                {
                    StartCoroutine(MoveSelection(currentSelection, next, .1f));
                    rectsInDirection.Clear();
                }
            }
        }
    }

    protected void CheckSelection(RectTransform currentSelection, PlayerController player)
    {
        currentSelectedAbility = currentSelectedRect.gameObject.GetComponent<AbilityImage>().abilityRef;
        Color tempColour = currentSelectedRect.gameObject.GetComponent<Image>().color;
        
        if (player.player.GetButtonDown("Menu Select"))
        {
            if (!currentSelectedAbility.isUnlocked)
            {
                if (currentSelectedAbility.AttemptBuyAbility())
                {
                    player.equippedAbility = currentSelectedAbility;
                    //Remove price text
                    //set image from faded to normal
                    tempColour.a = 255;
                    currentSelectedRect.gameObject.GetComponent<Image>().color = tempColour;
                }
                else
                {
                    //Do a failed effect?
                    return;
                }
            }
            else
            {
                player.equippedAbility = currentSelectedAbility;
            }
        }
        /*
         * get the ability from current selection
         * if APressed
         *  if(!isUnlocked)
         *  Ability.AttemptBuy
         *  else
         *  char.equippedAbility = ability
         */
    }

    private IEnumerator MoveSelection(RectTransform current, RectTransform next, float duration)
    {
        isSelectionMoving = true;
        current.anchorMin = next.anchorMin;
        current.anchorMax = next.anchorMax;
        currentSelectedRect = next;
        yield return new WaitForSeconds(duration);
        isSelectionMoving = false;
    }

    private RectTransform FindClosestRectInDirection(List<RectTransform> rects, PlayerController.DPadDirection dir)
    {
        float closestDist = 10000;
        RectTransform closestRect = null;

        switch (dir)
        {
            case PlayerController.DPadDirection.Up:
                foreach (RectTransform r in rects)
                {
                    float dist = Mathf.Abs(currentSelection.anchorMax.y - r.anchorMin.y);
                    if (dist < closestDist)
                    {
                        closestDist = dist;
                        closestRect = r;
                    }
                }
                return closestRect;

            case PlayerController.DPadDirection.Down:
                foreach (RectTransform r in rects)
                {
                    float dist = Mathf.Abs(currentSelection.anchorMin.y - r.anchorMax.y);
                    if (dist < closestDist)
                    {
                        closestDist = dist;
                        closestRect = r;
                    }
                }
                return closestRect;

            case PlayerController.DPadDirection.Left:
                foreach (RectTransform r in rects)
                {
                    float dist = Mathf.Abs(currentSelection.anchorMin.x - r.anchorMax.x);
                    if (dist < closestDist)
                    {
                        closestDist = dist;
                        closestRect = r;
                    }
                }
                return closestRect;

            case PlayerController.DPadDirection.Right:

                foreach (RectTransform r in rects)
                {
                    float dist = Mathf.Abs(currentSelection.anchorMax.x - r.anchorMin.x);
                    if (dist < closestDist)
                    {
                        closestDist = dist;
                        closestRect = r;
                    }
                }
                return closestRect;

            default:
                return null;
        }
    }

    private List<RectTransform> LocateRectsInDirection(PlayerController player, List<RectTransform> rects)
    {
        List<RectTransform> rectsInDir = new List<RectTransform>();
        switch (player.dPadDir)
        {
            case PlayerController.DPadDirection.Up:
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

            case PlayerController.DPadDirection.Down:
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

            case PlayerController.DPadDirection.Left:
                foreach (RectTransform r in rects)
                {
                    if (r == currentSelectedRect)
                    {
                        continue;
                    }

                    if (r.anchorMax.x < currentSelection.anchorMin.x)
                    {
                        Debug.Log($"Rect Name: {r.name} Rect AnchMax: {r.anchorMax.x} current anchmin: {currentSelection.anchorMin.x}");
                        rectsInDir.Add(r);
                    }
                }
                break;

            case PlayerController.DPadDirection.Right:

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
