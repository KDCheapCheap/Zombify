using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scout : PlayerController
{
    public override void Start()
    {
        base.Start();
        playerClass = PlayerClasses.Scout;
        baseSpeed = 10;
    }
}
