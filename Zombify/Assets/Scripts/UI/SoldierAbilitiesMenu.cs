using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SoldierAbilitiesMenu : Menu
{
    public GameObject AmmoPickup, SMGGift, ARGift, ShotgunGift, Grenade;

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

    protected override void Update()
    {
        base.Update();
        UpdateSelection(Soldier.instance);
        CheckSelection(currentSelectedRect, Soldier.instance);
    }

    private void CheckAbility()
    {
        if(currentSelectedRect.gameObject == AmmoPickup)
        {
            abilityID = 0;
        }

        if (currentSelectedRect.gameObject == SMGGift)
        {
            abilityID = 1;
        }

        if (currentSelectedRect.gameObject == ARGift)
        {
            abilityID = 2;
        }

        if (currentSelectedRect.gameObject == ShotgunGift)
        {
            abilityID = 3;
        }

        if (currentSelectedRect.gameObject == Grenade)
        {
            abilityID = 4;
        }
        
    }

}
