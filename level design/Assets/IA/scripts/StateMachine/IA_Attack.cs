using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Attack<T> : IState<T>
{
    Dictionary<T, IState<T>> dictionaryState = new Dictionary<T, IState<T>>();
    EnemyController enemy;
    Transform _firepoint;


    public IA_Attack(EnemyController e, Transform fp)
    {
        enemy = e;
        _firepoint = fp;
    }

    public void Execute()
    {
        Shoot();
        enemy.StartTree();
    }

    public void Awake()
    {
        Debug.Log("Awake de Attack");

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

    public void Shoot()
    {
        enemy.Attack();
    }


}
