using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform bulletTransform;
    public float speed = 10f;

    private void Awake()
    {
        bulletTransform = this.GetComponent<Transform>();

    }

    void Update()
    {
        bulletTransform.position += bulletTransform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject.Destroy(this.gameObject);
    }

}