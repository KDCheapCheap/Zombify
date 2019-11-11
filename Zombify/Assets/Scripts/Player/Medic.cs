using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medic : PlayerController
{
    public override void Start()
    {
        base.Start();
        playerClass = PlayerClasses.Medic;
        baseSpeed = 8;
    }
}
