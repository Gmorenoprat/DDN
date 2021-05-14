﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement 
{
    Player _player;
    Animator _animator;
    Rigidbody _rb;
    float _jumpForce = 1500f;
    float _rotateSpeed = 500f;

    float _speed ;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Transform _cam;
    Vector3 _cameraForward;
    Vector3 _cameraRight;




    public Movement(Player p, Animator a, Cinemachine.CinemachineFreeLook c)
    {
        _player = p;
        _rb = _player.GetComponent<Rigidbody>();
        _speed = _player.speed;
        _animator = a;

        _cam = c.transform;
        _cameraForward = new Vector3(_cam.forward.x, _player.transform.forward.y, _cam.forward.z);
        _cameraRight = new Vector3(_cam.right.x, _player.transform.forward.y, _cam.right.z);

    }

    public void Jump()  //SALTO NO VA___ ROLL SI
    {
        _player.isGrounded = false; 
        if (!_player.isGrounded) return;
        float jumpForce = _jumpForce;
        Vector2 force = new Vector2(0, jumpForce);
        _rb.AddForce(force, ForceMode.Impulse);
    }

    public void Move(float v, float h)
    {

        _cameraForward = new Vector3(_cam.forward.x, _player.transform.forward.y, _cam.forward.z);
        _cameraRight = new Vector3(_cam.right.x, _player.transform.forward.y, _cam.right.z);

        _player.transform.forward = Vector3.Slerp(_player.transform.forward, _cameraForward, Time.deltaTime * _rotateSpeed);

        //_rb.velocity = (_cameraForward * Input.GetAxis("Vertical") * _speed + _cameraRight * Input.GetAxis("Horizontal") * _speed);
        Vector3 X = _cameraRight * h * _speed;
        Vector3 Y = new Vector3(0f,_rb.velocity.y,0f);
        Vector3 Z= _cameraForward * v * _speed;
        _rb.velocity = (Z + Y + X);

        _animator.SetFloat("Speed_Forward", v); 
        _animator.SetFloat("Speed_Right", h);


        //Vector3 direction = new Vector3(h, 0, v).normalized;
        //if (direction.magnitude >= 0.1f)
        //{
        //    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        //    float angle = Mathf.SmoothDampAngle(_player.GetComponent<Transform>().eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        //    _player.GetComponent<Transform>().rotation = Quaternion.Euler(0f, angle, 0f);
        //}

    }



    public void Crouch()
    {
        _animator.SetBool("Crouched", true);
        slowDownSpeed(true);
    }
    public void StandUp()
    {
        _animator.SetBool("Crouched", false);
        slowDownSpeed(false);
    }

    public void Run()
    {
        _animator.SetBool("IsShooting", false);
    }

    public void slowDownSpeed(bool estaAgachado)
    {
        if (estaAgachado) _speed = _speed / 3;
        else if (!estaAgachado)_speed = _speed * 3;
    }
}

                          

