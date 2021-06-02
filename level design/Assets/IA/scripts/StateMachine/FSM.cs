using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM<T>
{
    public IState<T> _current;
    public FSM(IState<T> init)
    {
        if (init != null)
            SetInitialState(init);
    }
    public FSM() { }
    public void SetInitialState(IState<T> init)
    {
        _current = init;
        _current.Awake();
    }
    public void OnUpdate()
    {
        _current.Execute();
    }
    public void Transition(T input)
    {

        IState<T> newState = _current.GetState(input);
        if (newState == null)
        {
            //Debug.Log(_current.ToString() + " input is null " + input.ToString());
            return;
        }

        Debug.Log(" newState " + newState.ToString());
        _current.Sleep();
        newState.Awake();
        _current = newState;
    }
}
