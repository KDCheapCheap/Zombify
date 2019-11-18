using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGift : Ability
{
    public GameObject weaponPrefab;
    private float throwDistance = 6; //Distance it goes from player who through it
    private float rotSpeed = 3;

    private Color m_imageColour;
    private float imageLockedValue = 90f;
    private float imageUnlockedValue = 255f;

    private void Start()
    {
        //**SET COST IN INSPECTOR**
        activeTime = 15;
        cost = 3;
        cooldownTime = 1f;
        playerClass = PlayerController.PlayerClasses.Soldier;
        player = FindCorrectPlayer();
        m_imageColour.a = imageLockedValue;
        gameObject.SetActive(false);
        Debug.Log("Done");
    }

    private void OnEnable()
    {
        if (player != null)
        {
            StartCoroutine(Throw(player.lookAtPoint));
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!other.gameObject.GetComponent<PlayerController>().Weapons.Contains(weaponPrefab))
            {
                other.gameObject.GetComponent<PlayerController>().Weapons.Add(weaponPrefab);
                gameObject.SetActive(false);
            }
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
}
