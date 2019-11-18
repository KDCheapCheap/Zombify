using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Burst : Weapon
{
    private int burstAmount = 3;
    private float burstRate = 0.05f;
    private bool isBurstShooting = false;

    private void Start()
    {
        isBurstShooting = false;
    }

    public override void Shoot(bool increasedDamage, Animator anim)
    {
        //base.Shoot();
        if (!isBurstShooting)
        {
            if (currentBulletCount > 0)
            {
                anim.SetTrigger("Shoot");
                StartCoroutine(BurstSpawn(increasedDamage));
            }
            else if (currentBulletCount <= 0)
            {
                isReloading = true;
                StartCoroutine(Reload(reloadSpeed));
            }
        }
    }

    public IEnumerator BurstSpawn(bool increasedDamage)
    {
        isBurstShooting = true;
        for (int i = 0; i < burstAmount; i++)
        {
            yield return new WaitForSeconds(burstRate);
            SpawnBullet(increasedDamage);
        }

        StartCoroutine(ShootDelay(fireRate));
    }

    public override void SpawnBullet(bool increasedDamage)
    {
        if (currentBulletCount > 0)
        {
            Bullet bullet_ = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation) as Bullet;
            if (increasedDamage) { bullet_.damage *= 2; } 
            currentBulletCount -= 1;
            CameraShaker.Instance.ShakeOnce(2, 2.5f, .1f, .1f);
        }

        return;
    }

    public override IEnumerator ShootDelay(float t)
    {
        yield return new WaitForSeconds(t);
        canShoot = true;
        isBurstShooting = false;
    }
}
