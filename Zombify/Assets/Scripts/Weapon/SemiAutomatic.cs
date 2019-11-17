using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiAutomatic : Weapon
{

    public override void Shoot(bool increasedDamage)
    {
        //base.Shoot();
        if (canShoot && currentBulletCount > 0)
        {
            SpawnBullet(increasedDamage);
        }
        else if (currentBulletCount <= 0)
        {
            isReloading = true;

            StartCoroutine(Reload(reloadSpeed));
        }
    }
}
