using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Medic : PlayerController
{
    public static Medic instance;

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
        playerClass = PlayerClasses.Medic;
        baseSpeed = 8;
        player = ReInput.players.GetPlayer(2);
    }

    //public override void Update()
    //{
    //    if (InputManager.inputInstance.GetPlayer() == InputManager.inputInstance.medic)
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
