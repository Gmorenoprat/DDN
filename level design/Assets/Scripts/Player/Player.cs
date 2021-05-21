using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity , ICollector, IDamageable
{


    [Header("Movement")]
    public float speed;
    public bool isGrounded;
    public bool isRolling = false;
    [Header("Battle")]
    public bool canAttack;
    public bool isReloading;
    public Bullet bullet;
    public Transform bulletOrigin;
    [Header("HP/AR")]
    public float life;
    public float armor;
    PlayerController _control;
    Movement _movement;
    BattleMechanics _battleMechanics;
    SoundMananger _soundMananger;
   // AnimatorController _animatorController;
    public Animator _animator;
    public Camera cam ;

    public Transform CtSpawn;
    public Transform MafiaSpawn;


    private void Start()
    {
        cam = Camera.main;
        _animator = this.GetComponent<Animator>();
        _movement = new Movement(this, _animator, cam);
        _battleMechanics = new BattleMechanics(this, _animator);
        //_soundMananger = new SoundMananger(this);
       // _animatorController = new AnimatorController(_animator);
        _control = new PlayerController(this, _movement, _battleMechanics, null);

        _animator.SetBool("IsShooting", true); //ESTO NO VA ACA

    }
    void Update()
    {
        _control.OnUpdate();

        if (Input.GetKeyDown(KeyCode.F1)) { this.transform.position = CtSpawn.position; }
        if (Input.GetKeyDown(KeyCode.F2)) { this.transform.position = MafiaSpawn.position; }
    }

    public void Shoot()
    {
        Bullet b = Instantiate(bullet);
        b.transform.position = bulletOrigin.position;
        b.transform.forward = bulletOrigin.transform.forward;
    }

    public void ChangeWeapon(Bullet bullet)
    {
        this.bullet = bullet;
    }

    public void Die()
    {
        _animator.SetTrigger("Death");
        _animator.SetLayerWeight(_animator.GetLayerIndex("Shoot"), 0); 
    }
}

