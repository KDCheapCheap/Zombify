using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoPickup : Ability
{
    private float throwDistance = 6; //Distance it goes from player who through it
    private int ammoGiven = 30;

    public Image abilityTreeImage;
    private Color m_imageColour;
    private float imageLockedValue = 90f;
    private float imageUnlockedValue = 255f;

    public override void Init()
    {
        
        Debug.Log(player);
    }

    private void Start()
    {
        cost = 1;
        cooldownTime = 10f;
        playerClass = PlayerController.PlayerClasses.Soldier;
        player = FindCorrectPlayer();
        m_imageColour.a = imageLockedValue;
        gameObject.SetActive(false);
        Debug.Log("Done");
    }

    private void Update()
    {
        if(isUnlocked)
        {
            m_imageColour.a = imageUnlockedValue;
        }

        abilityTreeImage.color = m_imageColour;
    }

    private void OnEnable()
    {
        if (player != null)
        {
            StartCoroutine(Throw(player.lookAtPoint));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController p = collision.gameObject.GetComponent<PlayerController>();
        if (p != null)
        {
            if(!p.isGettingAmmo)
            StartCoroutine(GiveAmmo(p));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController p = collision.gameObject.GetComponent<PlayerController>();
        if (p != null)
        {
            p.isGettingAmmo = false;
            StopCoroutine(GiveAmmo(p));
        }
    }

    private IEnumerator Throw(Vector3 lookAtPoint)
    {
        float throwDuration = .7f;
        float throwTime = 0;
        Vector3 dir = (transform.position - -lookAtPoint).normalized; //Direction to throw to based on where player is looking

        while (throwTime < throwDuration)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + dir * throwDistance, Time.deltaTime * throwDuration); //Do throw
            throwTime += Time.deltaTime * throwDuration;
            yield return null;
        }
    }

    private IEnumerator GiveAmmo(PlayerController p)
    {
        p.isGettingAmmo = true;
        for (int i = 0; i < ammoGiven; i++)
        {
            yield return new WaitForSeconds(.3f);

            if (p.isGettingAmmo)
            {
                p.currentWeapon.totalAmmo += 1;
            }
            else
            {
                break;
            }
        }
        yield return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 1);
    }
}
