using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Abilities will be an empty game object with a script attached
 * the script will be a child of this class allowing all the functionality
 * When the player uses the ability, it will instantiate itself and the effect plays automatically
 * Once the effect is done, ability gets destroyed/set inactive
 */

public class Ability : MonoBehaviour
{
    protected bool isUnlocked;
    protected int cost;
    protected PlayerController player;
    public Ability[] parents;
    protected float cooldownTime;
    protected PlayerController.PlayerClasses playerClass;
    private bool onCooldown = false;

    protected virtual void Awake()
    {
        player = FindCorrectPlayer();
    }

    public virtual void Use() //Handles base functionality for using an ability
    {
        //instantiate object that runs it's own shit? Yeah go on then
        if (!onCooldown)
        {
            Instantiate(gameObject, player.transform.position, player.transform.rotation);
            onCooldown = false;
            StartCoroutine(Cooldown());

        }
        else
        {
            Debug.Log("On cooldown!");
        }
    }

    public bool AttemptBuyAbility()
    {
        if(player == null)
        {
            player = FindCorrectPlayer();
        }

        int parentCheckCount = 0;

        if (parents.Length != 0) //If it has a parent skill, check if that's unlocked
        {
            foreach (Ability a in parents) //Check if parent abilities are unlocked
            {
                if (a.isUnlocked)
                {
                    parentCheckCount++;
                }
            }

            if (parentCheckCount == parents.Length) //if all are unlocked
            {
                if (player.upgradePoints <= cost) //Check if player can afford skill
                {
                    isUnlocked = true;
                    player.upgradePoints -= cost; //Buy ability
                    return true;
                }
            }
            else
            {
                OnBuyFailed(); //Fail
                return false;
            }
        }
        else
        {
            if (player.upgradePoints >= cost)
            {
                isUnlocked = true;
                player.upgradePoints -= cost; //Buy ability
                return true;
            }
            else
            {
                OnBuyFailed();
                return false;
            }
        }
        return false;
    }

    private void OnBuyFailed()
    {
        Debug.LogError("This isn't unlocked yet!"); //Replace this with UI element later
    }

    private PlayerController FindCorrectPlayer()
    {
        switch (playerClass)
        {
            case PlayerController.PlayerClasses.Engineer:
                return GameObject.Find("Engineer").GetComponent<PlayerController>();

            case PlayerController.PlayerClasses.Medic:
                return GameObject.Find("Medic").GetComponent<PlayerController>();

            case PlayerController.PlayerClasses.Scout:
                return GameObject.Find("Scout").GetComponent<PlayerController>();

            case PlayerController.PlayerClasses.Soldier:
                return GameObject.Find("Soldier").GetComponent<PlayerController>();
            default:
                Debug.LogError("Player type not set in inspector!");
                return null;

        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        onCooldown = false;
    }
}
