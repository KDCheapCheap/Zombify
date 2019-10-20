using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

[System.Serializable]
public class Weapon : MonoBehaviour
{
    public int damage;
    public float fireRate; // this takes over the timeBetweenShots variable in the player
    public float reloadSpeed;
    public GameObject bullet;
    public GameObject shootPoint;
    public bool canShoot = true;
    public bool triggerReleased = true;

    public virtual void Shoot() {
    }

    public void SpawnBullet() {

        Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
        CameraShaker.Instance.ShakeOnce(2, 2.5f, .1f, .1f);
        canShoot = false;
        StartCoroutine(ShootDelay(fireRate));
 
    }

    public virtual IEnumerator ShootDelay(float t)
    {
        yield return new WaitForSeconds(t);
        canShoot = true;
    }

    public void Update()
    {

        if (Input.GetMouseButton(0))
        {
            triggerReleased = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            triggerReleased = true;
        }
    }
}
