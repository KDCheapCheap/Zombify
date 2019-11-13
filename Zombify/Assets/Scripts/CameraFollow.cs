using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private List<Transform> targets;
    private Vector3 centerPoint;
    private Vector3 newPosition;
    [SerializeField] private Vector3 offset;
    private void Start()
    {
        FindTargets();
    }

    void LateUpdate()
    {
        if (targets.Count == 0)
        {
            return;
        }

        Move();
    }

    void Move()
    {
        centerPoint = GetCenterPoint();
        newPosition = centerPoint + offset;

        transform.position = newPosition;
    }

    void Zoom()
    {

    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }
    void FindTargets()
    {
        foreach (GameObject p in GameObject.FindGameObjectsWithTag("Player"))
        {
            targets.Add(p.transform);
        }
    }
}
