using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int danio = 1;
    public Transform bulletTransform;
    public float speed = 10f;

    private void Awake()
    {
        bulletTransform = this.GetComponent<Transform>();

    }

    void Update()
    {
        bulletTransform.position += bulletTransform.forward * -speed * Time.deltaTime;
    }



}