using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG : Automatic
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 1;
        fireRate = .1f;
        reloadSpeed = 2;
        currentBulletCount = 20;
        totalAmmo = 150;
        magSize = 20;
        canShoot = true;
    }
}
