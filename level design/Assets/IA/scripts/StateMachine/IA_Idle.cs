using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Idle<T> : IState<T>
{
    Dictionary<T, IState<T>> _dic = new Dictionary<T, IState<T>>();
    EnemyController _enemy;

    public IA_Idle(EnemyController e)
    {
        _enemy = e;
    }

    public void Awake()
    {
        Debug.Log("Awake de IdleState");
    }

    public void Execute()
    {
        _enemy.GoPatrol();
    }

    public void Sleep()
    {

    }

    public void AddTransition(T input, IState<T> state)
    {
        if (!_dic.ContainsKey(input))
            _dic.Add(input, state);
    }
    public void RemoveTransition(T input)
    {
        if (_dic.ContainsKey(input))
            _dic.Remove(input);
    }
    public IState<T> GetState(T input)
    {
        if (_dic.ContainsKey(input))
            return _dic[input];
        return null;
    }

}
