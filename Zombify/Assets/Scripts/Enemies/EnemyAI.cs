using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

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
            float closestDist = 100;
            GameObject closestPlayer = players[0];

            foreach (GameObject p in players)
            {
                if(Vector3.Distance(transform.position, p.transform.position) < closestDist)
                {
                    closestPlayer = p;
                }
            }

            return closestPlayer.transform;
        }
    }
    private float baseSpeed;
    public float currentSpeed = 200;
    public float nextWaypointDistance = 3;
    public Status currentStatus;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    public int health;

    void Start()
    {
        baseSpeed = currentSpeed;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .5f);

    }


    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 dir = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = dir * currentSpeed * Time.deltaTime;

        rb.AddForce(force);

        float dist = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (dist < nextWaypointDistance)
        {
            currentWaypoint++;
        }

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

    }

    private void LookAtTarget()
    {
        Vector3 lookDir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * currentSpeed);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.SetActive(false); //Change to health--
            Destroy(collision.gameObject);
        }
    }

    public IEnumerator TakePosionDamage(int damage, float rate)
    {
        yield return new WaitForSeconds(rate);

        health -= damage;
    }
}
