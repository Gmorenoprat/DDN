using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed;
    Rigidbody _rb;
    public Transform player;
    ISteering _sb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _sb = new Seek(player, transform,3);
    }

    // Update is called once per frame
    void Update()
    {
        Move(_sb.GetDirection());
    }

    public void Move(Vector3 dir)
    {
        if (dir != Vector3.zero)
        {
            dir.y = 0;
            _rb.velocity = dir * speed;
            transform.forward = Vector3.Lerp(transform.forward, dir, 0.2f);
        }
    }
}
