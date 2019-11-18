using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoUI : Menu
{
    public enum PlayerType { Soldier, Engineer, Medic, Scout}
    public PlayerType playerType;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        type = MenuType.BottomPanel;
        GetPlayer();
    }

    protected override void OnShow()
    {
        MenuManager.Instance.TopBottomPanelOnShow(this, topBottomPanel);
    }

    protected override void Update()
    {
        if(player.player.GetAxis("Shoot") > 0.8 || player.isGettingAmmo)
        {
            if(!isShowing) //if hidden, show the menu
            {
                MenuManager.Instance.Show(this);
            }

            StopAllCoroutines();
            StartCoroutine(HideAfterInactivity(4));
        }
    }

    private IEnumerator HideAfterInactivity(float time)
    {
        yield return new WaitForSeconds(time); //Wait
        MenuManager.Instance.Hide(this); //Hide
        yield return null;
    }

    private void GetPlayer()
    {
        switch(playerType)
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
