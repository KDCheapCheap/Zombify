using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private List<Transform> targets;
    private Vector3 centerPoint;
    private Vector3 newPosition;
    [SerializeField] private Vector3 offset;

    private float minZoom = 8;
    private float maxZoom = 4;
    private Camera cam;

    private void Start()
    {
        cam = GetComponentInChildren<Camera>();
        FindTargets();
    }

    void LateUpdate()
    {
        if (targets.Count == 0)
        {
            return;
        }

        Move();
        Zoom();
    }

    void Move()
    {
        centerPoint = GetCenterPoint();
        newPosition = centerPoint + offset;

        transform.position = newPosition;
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / 50f);//GetGreatestDistance();
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        if (bounds.size.x > bounds.size.y)
        {
            return bounds.size.x;
        }
        else
        {
            return bounds.size.y;
        }
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
