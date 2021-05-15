﻿using UnityEngine;
using UnityEngine.AI;

public class Hostage : Entity
{

    public Entity _player;
    public NavMeshAgent _nav;
    public bool _follow;
    public AudioSource okLetsGO;
    public void Start()
    {
        _nav = this.GetComponent<NavMeshAgent>();
        okLetsGO = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(_player != null)
        {
            Follow();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.GetComponent<Entity>()) return;

        if (Input.GetKeyDown(KeyCode.E) && !_follow)
        {
            _follow = true;
            _player = other.GetComponent<Entity>();
            okLetsGO.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Q) && _follow)
        {
            _follow = false;
            _player = null;
        }
    }
    public void Follow()
    {
        _nav.SetDestination(_player.transform.position);
    }

    public void SetPlayer( Entity player)
    {
        _player = player;
    }
    public void RemovePlayer()
    {
        _player = null;
    }
}
