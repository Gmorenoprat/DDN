using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseView : MonoBehaviour
//Algo va a ir aca. Aun no lo tengo claro pero por herencia esta bueno tener la base you know
//Tal vez sea mejor meterle interfaz, pero por ahora es un abstract
{
    Animator _anim;
    public BaseView(Animator anim)
    {
        _anim = anim;
    }

}
