using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Engineer : PlayerController
{
    public static Engineer instance;

    private void Awake()
    {
        if (instance == null)
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
        playerClass = PlayerClasses.Engineer;
        baseSpeed = 5;
        player = ReInput.players.GetPlayer(1);
    }

    //public override void Update()
    //{
    //    if (InputManager.inputInstance.GetPlayer() == InputManager.inputInstance.engineer)
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
