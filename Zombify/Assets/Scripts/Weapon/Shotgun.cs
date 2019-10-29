using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Shotgun : Weapon
{

    [SerializeField]private int spreadAmount = 3;
    [SerializeField]private float spreadRange = 0.3f;

    public override void Shoot()
    {
        if (canShoot)
        {
            for (int i = 0; i <= spreadAmount; i++)
            {
                SpawnShotBullet();
            }
        }
    }

    public void SpawnShotBullet()
    {

        Instantiate(bullet, shootPoint.transform.position, 
            new Quaternion(shootPoint.transform.rotation.x + Random.Range(-spreadRange, spreadRange),
                           shootPoint.transform.rotation.y + Random.Range(-spreadRange, spreadRange),
                           shootPoint.transform.rotation.z,  shootPoint.transform.rotation.w));
        currentBulletCount -= 1;
        CameraShaker.Instance.ShakeOnce(2, 2.5f, .1f, .1f);
        canShoot = false;
        StartCoroutine(ShootDelay(fireRate));

    }
}
