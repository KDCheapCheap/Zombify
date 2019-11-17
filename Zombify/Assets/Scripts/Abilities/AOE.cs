using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : Ability
{
    public enum Type
    {
       Damage,
       Health
    }

    public bool isActive;
    public int effectRange;
    public Type myType;

    private void Update()
    {
        if (isActive) {
            GetAllNear();
        }
    }

    private void GetAllNear()
    {
        PlayerController[] aiInRange = GameObject.FindObjectsOfType<PlayerController>();

        foreach (PlayerController player_ in aiInRange)
        {
            float distanceSqr = (transform.position - player_.transform.position).sqrMagnitude;
            if (distanceSqr < effectRange)
            {
                EffectPlayer(player_);
            }
        }
    }

    private void EffectPlayer(PlayerController effectedBoi)
    {
        switch (myType)
        {
            case Type.Damage:
                StartCoroutine(effectedBoi.DamageDouble(10)); 
                break;
            case Type.Health:
                effectedBoi.isHealing = true;
                break;
        }
            
    }
}
