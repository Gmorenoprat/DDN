using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    public float life;

    void Update()
    {
        if(life <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        DestructorObject Destructor = collision.gameObject.GetComponent<DestructorObject>();

        if(Destructor != null)
        {
            life = life - Destructor.damage;
        }
    }
}
