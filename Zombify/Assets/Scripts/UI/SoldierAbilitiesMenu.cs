using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SoldierAbilitiesMenu : Menu
{
    //public Image skill1, skill2, skill3, skill4;

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
        UpdateSelection();
    }



}
