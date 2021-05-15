﻿
using UnityEngine;

public class PlayerController
{
    Player _player;
    Movement _movement;
    BattleMechanics _battle;


    SoundMananger _soundMananger;
    public PlayerController(Player p, Movement m, BattleMechanics b, SoundMananger s)
    {
        _player = p;
        _movement = m;
        _battle = b;
        _soundMananger = s;
    }

    public void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // if (_player.isGrounded) _soundMananger.SoundPlay((int)sounds.JUMP);
            _movement.Jump();
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        _player._animator.SetFloat("Speed_Forward", v);
        _player._animator.SetFloat("Speed_Right", h);

        if (v != 0 || h != 0)
        {
            //_player.GetComponent<Animator>().SetBool("Moving", true);
            _movement.Move(v, h);
        }
        _movement.Aim();
        //else _player.GetComponent<Animator>().SetBool("Moving", false);



        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _battle.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _movement.Crouch();
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            _movement.StandUp();
        }


    }
}