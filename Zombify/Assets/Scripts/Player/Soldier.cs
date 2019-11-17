using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Soldier : PlayerController
{
    public static Soldier instance;

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
        playerClass = PlayerClasses.Soldier;
        baseSpeed = 7;
        player = ReInput.players.GetPlayer(0);
    }

    //public override void Update()
    //{
    //    if (InputManager.inputInstance.GetPlayer() == InputManager.inputInstance.soldier)
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
