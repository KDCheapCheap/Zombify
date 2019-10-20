using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    private void Start()
    {
        damage = 2;
        fireRate = .7f;
        reloadSpeed = 4;
        canShoot = true;
    }
}
