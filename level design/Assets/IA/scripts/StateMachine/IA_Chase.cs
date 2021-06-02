using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Chase<T> : IState<T>
{
    Dictionary<T, IState<T>> dictionaryState = new Dictionary<T, IState<T>>();
    EnemyController enemy;
    Rigidbody enemyRigidbody;
    Transform playerTransform;
    //Seek seek;
    float dodgeStrenght = 10;
    float dodgeRadius = 10;
    float minDistance = 2.5f;
    Vector3 dir;
    float speed = 2;

    Seek seek;

    private float RotationSpeed = 2.0f;


    public IA_Chase(EnemyController enemy, Rigidbody rb, float ds = 10, float dr = 20, float s = 4)
    {
        this.enemy = enemy;
        enemyRigidbody = rb;
        dodgeStrenght = ds;
        dodgeRadius = dr;
        speed = s;
    }

    public void Awake()
    {
        Debug.Log("Awake de CHASE");

        playerTransform = Object.FindObjectOfType<Player>().transform;
        enemy.keepChasing = true;
        seek = new Seek(enemy.transform, playerTransform.transform, 3);
    }

    public void Execute()
    {
        Move();
        enemy.StartTree();
    }

    public void Sleep()
    {

    }

    public void AddTransition(T input, IState<T> state)
    {
        if (!dictionaryState.ContainsKey(input))
            dictionaryState.Add(input, state);
    }
    public void RemoveTransition(T input)
    {
        if (dictionaryState.ContainsKey(input))
            dictionaryState.Remove(input);
    }
    public IState<T> GetState(T input)
    {
        if (dictionaryState.ContainsKey(input))
            return dictionaryState[input];
        return null;
    }
    public void Move()
    {
        //dir = seek.GetDirection();
        //dir.y = 0;
        //dir = dir.normalized;
        ////enemyRigidbody.velocity = dir * speed;
        //enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, dir, 0.2f);

        //enemy.transform.forward = Vector3.Lerp(enemy.transform.forward, dir, 0.2f);
        Walk();
    }

    public void Walk()
    {

        float MovementStep = speed * Time.deltaTime;
        float RotationStep = RotationSpeed * Time.deltaTime;

        Vector3 LookAtWayPoint = playerTransform.position - enemy.transform.position;
        Quaternion RotationToTarget = Quaternion.LookRotation(LookAtWayPoint);

        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, RotationToTarget, RotationStep);

        float distance = Vector3.Distance(enemy.transform.position, playerTransform.position);

        if (distance < minDistance)
            return;


        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, playerTransform.position + AvoidObstacle(), MovementStep);
    }

    public Vector3 AvoidObstacle()
    {
        Vector3 avoidDir = Vector3.zero;

        Collider[] obstacles = Physics.OverlapSphere(enemy.transform.position, dodgeRadius, LayerMask.GetMask("Ambient"));


        if (obstacles.Length > 0)
        {
            float minDistance = Vector3.Distance(obstacles[0].transform.position, enemy.transform.position);
            int index = 0;
            for (int i = 1; i < obstacles.Length; i++)
            {
                //Debug.Log("AvoidObstacle 3 " + i);

                float currentDistance = Vector3.Distance(enemy.transform.position, obstacles[i].transform.position);
                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    index = i;
                }
            }
            avoidDir = (obstacles[index].transform.position - enemy.transform.position).normalized * ((dodgeRadius - minDistance) / dodgeRadius) * dodgeStrenght * -1f;
            dir += avoidDir;
        }

        return avoidDir.normalized;
    }
}
