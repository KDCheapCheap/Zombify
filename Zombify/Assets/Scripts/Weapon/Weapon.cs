﻿using System.Collections;
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
    public bool isReloading = false;

    [HideInInspector] public int totalAmmo;
    [HideInInspector] public int magSize;
    [HideInInspector] public int currentBulletCount;

    public virtual void Shoot()
    {
        StartCoroutine(ShootDelay(fireRate));
    }

    public virtual void SpawnBullet()
    {

        Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
        currentBulletCount -= 1;
        CameraShaker.Instance.ShakeOnce(2, 2.5f, .1f, .1f);
        canShoot = false;
        StartCoroutine(ShootDelay(fireRate));

    }

    public virtual IEnumerator ShootDelay(float t)
    {
        yield return new WaitForSeconds(t);
        canShoot = true;
    }

    public virtual IEnumerator Reload(float reloadSpeed)
    {
        yield return new WaitForSeconds(reloadSpeed);
        while (isReloading)
        {
            if (totalAmmo >= magSize)
            {
                currentBulletCount = magSize;
                totalAmmo -= magSize;
                isReloading = false;
            }
            else
            {
                currentBulletCount = totalAmmo;
                totalAmmo = 0;
                isReloading = false;
            }
            yield return null;
        }
        isReloading = false;
        yield return null;
    }
}