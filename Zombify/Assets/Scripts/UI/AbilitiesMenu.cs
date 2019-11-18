using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class AbilitiesMenu : Menu
{
    public enum PlayerType { Soldier, Engineer, Medic, Scout }
    public PlayerType playerType;


    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        type = MenuType.LeftSidePanel;
        currentSelection.anchoredPosition = totalAbilties[0].anchoredPosition;
        currentSelectedRect = totalAbilties[0];
        GetPlayer();
    }

    protected override void OnShow()
    {
        MenuManager.Instance.SidePanelOnShow(this, leftRightPanel);
    }

    protected override void Update()
    {
        base.Update();
        UpdateSelection(player);
        CheckSelection(currentSelectedRect, player);
    }

    private void GetPlayer()
    {
        switch (playerType)
        {
            case PlayerType.Soldier:
                player = Soldier.instance;
                break;

            case PlayerType.Engineer:
                player = Engineer.instance;
                break;

            case PlayerType.Medic:
                player = Medic.instance;
                break;

            case PlayerType.Scout:
                player = Scout.instance;
                break;
        }
    }
}
