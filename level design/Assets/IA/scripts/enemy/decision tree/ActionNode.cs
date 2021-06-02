using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionNode : INode
{
    public delegate void NodeAction();
    NodeAction _myAction;

    public ActionNode(NodeAction a)
    {
        _myAction = a;
    }

    public void Execute()
    {
        _myAction();
    }
}
