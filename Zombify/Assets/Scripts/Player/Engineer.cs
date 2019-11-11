using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engineer : PlayerController
{
    public override void Start()
    {
        base.Start();
        playerClass = PlayerClasses.Soldier;
        baseSpeed = 5;
    }
}
