using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionNode : INode
{
    public delegate bool NodeQuestion();
    NodeQuestion _myQuestion;

    INode _trueNode;
    INode _falseNode;

    public QuestionNode(NodeQuestion q, INode trueCase, INode falseCase)
    {
        _myQuestion = q;
        _trueNode = trueCase;
        _falseNode = falseCase;
    }

    public void Execute()
    {

        if (_myQuestion())
        {
            _trueNode.Execute();
        }
        else
        {
            _falseNode.Execute();
        }
    }
}