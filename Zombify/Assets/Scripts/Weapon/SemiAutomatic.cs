using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiAutomatic : Weapon
{

    public override void Shoot(bool increasedDamage, Animator anim)
    {
        //base.Shoot();
        if (canShoot && currentBulletCount > 0)
        {
            anim.SetTrigger("Shoot");
            SpawnBullet(increasedDamage);
        }
        else if (currentBulletCount <= 0)
        {
            isReloading = true;

            StartCoroutine(Reload(reloadSpeed));
        }
    }
}
