using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateLineOfSight
{
    Chase,
    Attack
}
public class LineOfSight : MonoBehaviour
{
    public float range;
    public float angle;
    public Transform target;
    public LayerMask obstacleLayer;

    public bool IsInSight(Transform target, float range = 30)
    {
        this.range = range;
        if (target == null)
            return false;

        float distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget > range) return false;
        float angleToTarget = Vector3.Angle(transform.forward, (target.position - transform.position));
        if (angleToTarget > angle / 2) return false;
        Vector3 direction = target.position - transform.position;
        if (Physics.Raycast(transform.position, direction, distanceToTarget, obstacleLayer)) return false;
        return true;
    }

    private void OnDrawGizmos()
    {
        if (target == null)
            return;

        if (IsInSight(target,range)) Gizmos.color = Color.green;
        else Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, angle / 2, 0) * transform.forward * range);
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, -angle / 2, 0) * transform.forward * range);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, (target.position - transform.position).normalized * range);
    }
}
