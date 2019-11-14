using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SoldierAbilitiesMenu : Menu
{
    public Image skill1, skill2, skill3, skill4;
    [SerializeField] private RectTransform parentPanel;
    // Start is called before the first frame update
    void Start()
    {
        type = MenuType.LeftSidePanel;
    }

    protected override void OnShow()
    {
        MenuManager.Instance.SidePanelOnShow(this, leftRightPanel);
    }
}
