using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFSM<T>
{
    BaseState<T> _current;
    public BaseFSM(BaseState<T> init)
    {
        if (init != null)
            SetInit(init);
    }
    public BaseFSM() { }
    public void SetInit(BaseState<T> init)
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
        BaseState<T> newState = _current.GetState(input);
        if (newState == null) return;
        _current.Sleep();
        newState.Awake();
        _current = newState;
    }
}