using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Burst : Weapon
{
    private int burstAmount = 3;
    private float burstRate = 0.05f;

    public override void Shoot()
    {
        //base.Shoot();
        if (!isBurstShooting)
        {
            StartCoroutine(BurstSpawn());
        }
    }
    private void Update()
    {
        Debug.Log(isBurstShooting);
    }

    public IEnumerator BurstSpawn()
    {
        isBurstShooting = true;
        for (int i = 0; i < burstAmount; i++)
        {
            yield return new WaitForSeconds(burstRate);
            SpawnBullet();
        }

        StartCoroutine(ShootDelay(fireRate));
    }

    public override void SpawnBullet()
    {
        Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
        CameraShaker.Instance.ShakeOnce(2, 2.5f, .1f, .1f);
    }
}
