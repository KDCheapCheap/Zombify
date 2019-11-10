using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : Ability
{
    

    private float throwDistance = 3; //Distance it goes from player who through it
    private int ammoGiven = 30;
    private int lifeDuration = 5;

    protected override void Awake()
    {
        cost = 1;
        cooldownTime = 10f;
        playerClass = PlayerController.PlayerClasses.Soldier;
        base.Awake(); //Must be called after playerClass is assigned!!
    }

    private void Start()
    {
        //playerRef = GameObject.Find("Soldier").GetComponent<PlayerController>();
        StartCoroutine(Throw(player.lookAtPoint));
        Destroy(gameObject, lifeDuration); //Get rid of object after so long as to not litter the world
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject c = collision.gameObject;
        PlayerController playerRef = null;
        if(c.CompareTag("Player"))
        {
            playerRef = c.GetComponent<PlayerController>();
            playerRef.currentWeapon.totalAmmo += ammoGiven;
            Destroy(gameObject);
        }
    }

    private IEnumerator Throw(Vector3 lookAtPoint)
    {
        float throwDuration = .7f;
        float throwTime = 0;
        Vector3 dir = (transform.position - lookAtPoint).normalized; //Direction to throw to based on where player is looking

        while(throwTime < throwDuration)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + dir * throwDistance, Time.deltaTime * throwDuration); //Do throw
            throwTime += Time.deltaTime * throwDuration;
            yield return null;
        }
    }
}
