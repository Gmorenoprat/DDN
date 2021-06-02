using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : ISteering
{
    Transform _target;
    Transform _transform;
    float _distance;

    float dodgeStrenght = 10;
    float dodgeRadius = 10;
    public Seek(Transform to, Transform from, float dist)
    {
        _target = to;
        _transform = from;
        _distance = dist;
    }

    public Vector3 GetDirection()
    {
        //if (Vector3.Distance(_target.position, _transform.position) > _distance)
        //{
        //    Vector3 direction = (_target.position - _transform.position).normalized;
        //    return direction;
        //}
        //else return Vector3.zero;

        Vector3 dir = (_target.position - _transform.position).normalized;


        Collider[] obstacles = Physics.OverlapSphere(_transform.position, dodgeRadius, LayerMask.GetMask("Obstacle"));
        if (obstacles.Length > 0)
        {
            float minDistance = Vector3.Distance(obstacles[0].transform.position, _transform.position);
            int index = 0;
            for (int i = 1; i < obstacles.Length; i++)
            {
                float currentDistance = Vector3.Distance(_transform.position, obstacles[i].transform.position);
                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    index = i;
                }
            }
            Vector3 avoidDir = (obstacles[index].transform.position - _transform.position).normalized * ((dodgeRadius - minDistance) / dodgeRadius) * dodgeStrenght * -1f;
            dir += avoidDir;
        }


        return dir.normalized;  
    }
}
