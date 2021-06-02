using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToPoints : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private Transform targetMyPoint;
    private int targetMyPointIndex =0;
    private int LastargetMyPointIndex;
    private float MinDistance = 0.1f;

    public float Speed;
    private float RotationSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        LastargetMyPointIndex = waypoints.Count - 1;
        targetMyPoint = waypoints[targetMyPointIndex];
    }

  
    public void Walk()
    {

        float MovementStep = Speed * Time.deltaTime;
        float RotationStep = RotationSpeed * Time.deltaTime;

        Vector3 LookAtWayPoint = targetMyPoint.position - transform.position;
        Quaternion RotationToTarget = Quaternion.LookRotation(LookAtWayPoint);

        transform.rotation = Quaternion.Slerp(transform.rotation, RotationToTarget, RotationStep);

        float distance = Vector3.Distance(transform.position, targetMyPoint.position);

        CheckWayPoint(distance);
        transform.position = Vector3.MoveTowards(transform.position, targetMyPoint.position, MovementStep);
    }
    void CheckWayPoint(float currentDistance)
    {
        if(currentDistance<=MinDistance)
        {
            targetMyPointIndex++;
            UpdateWayPoint();
        }
    }
    void UpdateWayPoint()
    {
        if(targetMyPointIndex>LastargetMyPointIndex)
        {
            targetMyPointIndex = 0;
        }
        targetMyPoint = waypoints[targetMyPointIndex];
    }
}
