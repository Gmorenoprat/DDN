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
    public Weapon activeWeapon;
    [Header("HP/AR")]
    public float life;
    public float armor;
    PlayerController _control;
    Movement _movement;
    BattleMechanics _battleMechanics;
    SoundMananger _soundMananger;
    public Animator _animator;
    public Camera cam ;

   // AnimatorController _animatorController;

    //Debug pourpuse
    public Transform CtSpawn;
    public Transform MafiaSpawn;


    private void Start()
    {
        cam = Camera.main;
        _animator = this.GetComponent<Animator>();
        _movement = new Movement(this, _animator, cam);
        _battleMechanics = new BattleMechanics(this, activeWeapon, _animator);
        _control = new PlayerController(this, _movement, _battleMechanics, null);
        //_soundMananger = new SoundMananger(this);
       // _animatorController = new AnimatorController(_animator);

        _animator.SetBool("IsShooting", true); //ESTO NO VA ACA

    }
    void Update()
    {
        _control.OnUpdate();

        //FORDEBUG
        if (Input.GetKeyDown(KeyCode.F1)) { this.transform.position = CtSpawn.position; }
        if (Input.GetKeyDown(KeyCode.F2)) { this.transform.position = MafiaSpawn.position; }
    }

    public void GetDamage(float dmg)
    {
        life -= dmg;
    }

    //public void Die()
    //{
    //    _animator.SetTrigger("Death");
    //    _animator.SetLayerWeight(_animator.GetLayerIndex("Shoot"), 0); 
    //}
}

