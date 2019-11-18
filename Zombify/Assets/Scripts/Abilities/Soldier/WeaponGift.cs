using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGift : MonoBehaviour
{
    public enum GiftWeapon { SMG, AR, Shotgun }
    public GameObject weaponPrefab;
    public GiftWeapon weapon;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!other.gameObject.GetComponent<PlayerController>().Weapons.Contains(weaponPrefab))
            {
                other.gameObject.GetComponent<PlayerController>().Weapons.Add(weaponPrefab);
                Destroy(gameObject);
            }
        }
    }
}
