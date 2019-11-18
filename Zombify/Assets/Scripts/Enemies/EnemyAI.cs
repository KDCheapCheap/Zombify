using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class EnemyAI : MonoBehaviour
{

    public enum Status
    {
        Normal,
        Stunned,
        Posioned,
        Slowed,
        Confused,
        Distracted
    }

    public Transform target
    {
        get
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            GameObject decoy = GameObject.FindGameObjectWithTag("Decoy");
            float closestDist = 100;
            GameObject closestPlayer = players[0];

            foreach (GameObject p in players)
            {
                float dist = Vector3.Distance(transform.position, p.transform.position);

                if (dist < closestDist)
                {
                    closestPlayer = p;
                    closestDist = dist;
                }
            }
            float rand = Random.Range(0f, 1f);

            if (decoy != null && rand > 0.7f)
            {
                currentStatus = Status.Distracted;
                return decoy.transform;
            }
            else
            {
                return closestPlayer.transform;
            }
        }
    }
    private float baseSpeed = 7;
    public float currentSpeed = 7;
    public float nextWaypointDistance = 3;
    public Status currentStatus;
    private NavMeshAgent nav;
    int currentWaypoint = 0;
    public int health;
    public GameObject upgradePoint;
    private bool isAttacking;
    private float attackTime = 1.5f;


    private Animator anim;
    void Start()
    {
        baseSpeed = currentSpeed;
        nav = GetComponent<NavMeshAgent>();
        health = 3;
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        if (currentStatus == Status.Stunned)
        {
            return;
        }
        if (currentStatus == Status.Distracted)
        {
            if (GameObject.FindGameObjectWithTag("Decoy") != null)
            {
                return;
            }
            else
            {
                currentStatus = Status.Normal;
            }

        }

        nav.speed = currentSpeed;

        LookAtTarget();

        switch (currentStatus)
        {
            case Status.Slowed:
                currentSpeed = baseSpeed / 2;
                break;
            case Status.Posioned:
                StartCoroutine(TakePosionDamage(1, 1));
                break;
            case Status.Stunned:
            case Status.Confused:
            default:
                currentSpeed = baseSpeed;
                break;
        }

        Debug.Log($"Distance: {Vector3.Distance(transform.position, target.position)}");

        if (Vector3.Distance(transform.position, target.position) > 1.8f)
        {
            nav.SetDestination(target.position);
        }
        else
        {
            if (!isAttacking)
            {
                isAttacking = true;
                anim.SetTrigger("Attack");
                StartCoroutine(Attack());
            }
        }

        if (health <= 0)
        {
            Die();
        }
    }

    private void LookAtTarget()
    {
        Vector3 lookDir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(lookDir.z, lookDir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * currentSpeed);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= collision.gameObject.GetComponent<Bullet>().damage;
        }
    }

    private IEnumerator Attack()
    {
        target.gameObject.GetComponent<PlayerController>().health -= 2;
        yield return new WaitForSeconds(attackTime);
        isAttacking = false;
    }

    public IEnumerator TakePosionDamage(int damage, float rate)
    {
        yield return new WaitForSeconds(rate);

        health -= damage;
    }

    public IEnumerator UpdateStatus(Status status_, float timer)
    {
        currentStatus = status_;

        yield return new WaitForSeconds(timer);

        currentStatus = Status.Normal;
    }

    public void Die()
    {
        float rand = Random.Range(0f, 1f);


        if (rand > 0.8f)
        {
            Instantiate(upgradePoint, transform.position, transform.rotation);
        }

        SpawnPooler.poolInstance.spawnedEnemies.Remove(gameObject);
        Destroy(gameObject);
    }
}
