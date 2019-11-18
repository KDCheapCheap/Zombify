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
    public Bullet bullet;
    public GameObject shootPoint;
    public bool canShoot = true;
    public bool isReloading = false;

    [HideInInspector] public int totalAmmo;
    [HideInInspector] public int magSize;
    [HideInInspector] public int currentBulletCount;

    public virtual void Shoot(bool increasedDamage, Animator anim)
    {
        StartCoroutine(ShootDelay(fireRate));
    }

    public virtual void Shoot()
    {
        StartCoroutine(ShootDelay(fireRate));
    }

    public virtual void SpawnBullet(bool increasedDamage)
    {
        Bullet bullet_ = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation) as Bullet;
        if (increasedDamage) { bullet_.damage *= 2; }
        currentBulletCount -= 1;
        CameraShaker.Instance.ShakeOnce(.2f, .25f, .01f, .01f);
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
        if (isReloading)
        {
            if (totalAmmo == 0)
            {
                yield return null;
            }
            else if (totalAmmo >= magSize)
            {
                int amountToReload = magSize - currentBulletCount;
                currentBulletCount = magSize;
                totalAmmo -= amountToReload;
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
