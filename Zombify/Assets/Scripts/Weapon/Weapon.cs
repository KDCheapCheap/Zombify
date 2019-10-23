using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

[System.Serializable]
public class Weapon : MonoBehaviour
{
    public int damage;
    public float fireRate;
    public float reloadSpeed;
    public GameObject bullet;
    public GameObject shootPoint;
    public bool canShoot = true;
    public bool isBurstShooting;

    public virtual void Shoot()
    {
        StartCoroutine(ShootDelay(fireRate));
    }

    public virtual void SpawnBullet()
    {

        Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
        CameraShaker.Instance.ShakeOnce(2, 2.5f, .1f, .1f);
        canShoot = false;
        StartCoroutine(ShootDelay(fireRate));

    }

    public virtual IEnumerator ShootDelay(float t)
    {
        yield return new WaitForSeconds(t);
        canShoot = true;
        isBurstShooting = false;
    }
}
