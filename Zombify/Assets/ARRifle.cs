using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARRifle : Burst
{
    // Start is called before the first frame update
    void Start()
    {
        fireRate = 1.5f;
        damage = 2;
        fireRate = .3f;
        reloadSpeed = 4;
        canShoot = true;
    }
}
