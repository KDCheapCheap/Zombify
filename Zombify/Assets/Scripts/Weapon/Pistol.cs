using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : SemiAutomatic
{
    private void Start()
    {
        damage = 2;
        fireRate = 2f;
        reloadSpeed = 2.5f;
        canShoot = true;
    }
}
