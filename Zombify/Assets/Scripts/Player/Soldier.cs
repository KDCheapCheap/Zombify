using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : PlayerController
{

    public override void Awake()
    {
        base.Awake();
    }
    public override void Start()
    {
        base.Start();
        playerClass = PlayerClasses.Soldier;
        baseSpeed = 7;
    }
    

}
