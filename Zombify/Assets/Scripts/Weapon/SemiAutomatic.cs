using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiAutomatic : Weapon
{
    
    public override void Shoot()
    {
        base.Shoot();

        if (triggerReleased)
        {
            if (canShoot) {
                SpawnBullet();
            }
        }
    }
}
