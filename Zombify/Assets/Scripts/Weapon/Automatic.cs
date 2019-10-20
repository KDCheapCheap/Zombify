using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automatic : Weapon
{
    public override void Shoot()
    {
        SpawnBullet();
    }
}
