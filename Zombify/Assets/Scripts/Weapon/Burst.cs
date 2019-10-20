using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst : Weapon
{
    public int burstAmount = 3;
    public float burstRate = 0.3f;

    public override void Shoot()
    {
        if (triggerReleased)
        {
            if (canShoot)
            {
               StartCoroutine(BurstSpawn());
            }
        }
    }

    public IEnumerator BurstSpawn() {
        for (int i = 0; i < burstAmount; i++)
        {
            yield return new WaitForSeconds(burstRate);
            SpawnBullet();
        }
    }
}
