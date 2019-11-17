using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public enum Status
    {
        Normal,
        Stunned,
        Posioned,
        Slowed,
        Confused
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
            float rand = Random.Range(0, 1);

            if (decoy != null && rand > 0.5f)
            {
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

    void Start()
    {
        baseSpeed = currentSpeed;
        nav = GetComponent<NavMeshAgent>();
        InvokeRepeating("UpdatePath", 0f, .5f);

    }


    void FixedUpdate()
    {
        if (currentStatus == Status.Stunned)
        {
            return;
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
<<<<<<< HEAD
        if (Vector3.Distance(transform.position, target.position) > .3f)
        {
            nav.SetDestination(target.position);
        }
=======

        if (health >= 0)
        {
            Die();
        }

>>>>>>> origin/Development
    }

    private void LookAtTarget()
    {
        Vector3 lookDir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * currentSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.GetComponent<Bullet>();
            health -= bullet.damage; 
            Destroy(collision.gameObject);
        }
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
        gameObject.SetActive(false);
        //add back to pool
    } 
}
