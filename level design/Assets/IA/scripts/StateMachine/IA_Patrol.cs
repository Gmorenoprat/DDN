using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Patrol<T> : IState<T>
{
    Dictionary<T, IState<T>> dictionaryState = new Dictionary<T, IState<T>>();
    EnemyController enemy;
    Vector3 dir;
    float speed = 2;
    WalkToPoints walktoPoints;
    Rigidbody rigidbody;

    public IA_Patrol(EnemyController enemy, Rigidbody rigidbody,WalkToPoints walktoPoints , float s = 5)
    {
        this.enemy = enemy;
        this.rigidbody = rigidbody;
        this.walktoPoints = walktoPoints;
        speed = s;
    }

    public void Awake()
    {
        enemy.keepChasing = false;
        Debug.Log("Awake de Patrol");
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
        walktoPoints.Walk();
        //dir = walktoPoints.M;
        //dir.y = 0;
        //dir = dir.normalized;
        //rigidbody.velocity = dir * speed;

        //enemy.transform.forward = Vector3.Lerp(, dir, 0.2f);
    }
}
