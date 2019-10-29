using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiAutomatic : Weapon
{

    public override void Shoot()
    {
        //base.Shoot();
        if (canShoot && currentBulletCount > 0)
        {
            SpawnBullet();
        }
        else if (currentBulletCount <= 0)
        {
            isReloading = true;

            StartCoroutine(Reload(reloadSpeed));
        }
    }
}
