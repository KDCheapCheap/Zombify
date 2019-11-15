using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SoldierAbilitiesMenu : Menu
{
    public Image skill1, skill2, skill3, skill4;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        type = MenuType.LeftSidePanel;
    }

    protected override void OnShow()
    {
        MenuManager.Instance.SidePanelOnShow(this, leftRightPanel);
    }

//    Selction

//List<RectTransform> totalAbilities
//RectTransform currentAbilitySelection

//switch(dir)
//case right:
//RectTransform[] rightRects = LocateRectsRight()
//float closestDist = 10000
//RectTransform closestRect
//foreach(RectTransform r in rightRects)
//    {
//        float dist = mathf.abs(currentAbilitySelection.anchMax.y, r.anchMin.x)

//    if (dist < closestDist)
//            closestRect = r
//}
//    currentAbilitySelection.position = closestRect.position
    //Maybe set the size/anchors the same?
}
