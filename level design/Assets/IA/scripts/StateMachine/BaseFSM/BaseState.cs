using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState<T>
{
    Dictionary<T, BaseState<T>> _adjacentStates = new Dictionary<T, BaseState<T>>();
    BaseView _view;
    //Aca setearias el view de base, asi despues al hacer herencia esto ya esta hecho
    public BaseState(BaseView view)
    {
        _view = view;
    }
    //Por que usarias este getstate? No le encuentro uso
    public BaseState<T> GetState(T input)
    {
        if (_adjacentStates.ContainsKey(input))
            return _adjacentStates[input];
        return null;
    }
    public virtual void Awake() { }
    public virtual void Execute() { }
    public virtual void Sleep() { }
    public void AddTransition(T input, BaseState<T> state)
    {
        if (!_adjacentStates.ContainsKey(input))
            _adjacentStates.Add(input, state);
    }
    public void RemoveTransition(T input)
    {
        if (_adjacentStates.ContainsKey(input))
            _adjacentStates.Remove(input);
    }
}