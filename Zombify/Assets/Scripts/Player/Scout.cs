using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Scout : PlayerController
{

    public static Scout instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public override void Start()
    {
        base.Start();
        playerClass = PlayerClasses.Scout;
        baseSpeed = 10;
        player = ReInput.players.GetPlayer(3);
    }

    //public override void Update()
    //{
    //    if (InputManager.inputInstance.GetPlayer() == InputManager.inputInstance.scout)
    //    {
    //        LookAtStick();
    //        Movement();
    //        CheckInput();
    //        Sprint();
    //        Shoot();
    //    }
    //    base.Update();
    //}

}
