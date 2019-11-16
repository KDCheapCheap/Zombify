using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Ability
{
    public enum GrenadeType
    {
        Damage,
        Stun,
        Poison
    }

    public float explodTimer;
    public int explosionRadius;
    public GrenadeType myType;
    [SerializeField]private int damage;
    [SerializeField]private int effectTimer;

    public void Start()
    {
        //StartCoroutine(ExplodeAfter(explodTimer))
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Explode(explosionRadius);
        }
    }

    private IEnumerator ExplodeAfter(float timeToExplode)
    {
        yield return new WaitForSeconds(timeToExplode);

        Explode(explosionRadius);
    }

    private void Explode(int grenadeRange)
    {
        //Visual Effect
        //Sound Effect
        GetNearby(grenadeRange);
        //Destroy(this);
    }

    private void GetNearby(int grenadeRange)
    {
        EnemyAI[] aiInRange = GameObject.FindObjectsOfType<EnemyAI>();

        foreach (EnemyAI deadBoi in aiInRange)
        {
            float distanceSqr = (transform.position - deadBoi.transform.position).sqrMagnitude;
            if (distanceSqr < grenadeRange)
            {
                EffectEnemy(deadBoi);
            }
        }
    }

    private void EffectEnemy(EnemyAI unluckyBoi)
    {
        switch (myType)
        {
            case GrenadeType.Damage:
                unluckyBoi.health -= damage;
                break;
            case GrenadeType.Stun:
                StartCoroutine(unluckyBoi.UpdateStatus(EnemyAI.Status.Stunned, effectTimer));
                break;
            case GrenadeType.Poison:
                StartCoroutine(unluckyBoi.UpdateStatus(EnemyAI.Status.Posioned, effectTimer));
                break;
        } 
    }
}
