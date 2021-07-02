using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity , ICollector, IDamageable, IObservable
{
    [Header("Movement")]
    public float speed;
    public bool isGrounded;
    public bool isRolling = false;

    [Header("Battle")]
    public bool canAttack;
    public bool isReloading;
    public bool isShooting;
    public Bullet bullet;
    public Transform bulletOrigin;
    public Weapon activeWeapon;
    public Transform grenadeOrigin;
    public Grenades grenades;

    [Header("HP/AR")]
    public float life;
    public float armor;
    PlayerController _control;
    PlayerView _playerView;
    Movement _movement;
    BattleMechanics _battleMechanics;
    SoundMananger _soundMananger;
    AnimatorController _animatorController;
    public Animator _animator;
    public Camera cam ;

    public Weapon ActiveWeapon{ get { return activeWeapon; } set { activeWeapon = value; } }
    public Grenades ActiveGrenades{ get { return grenades; } set { grenades = value; } }


    //Debug pourpuse
    public Transform CtSpawn;
    public Transform MafiaSpawn;

    private void Start()
    {
        cam = Camera.main;
        grenades.setSpawnPos(grenadeOrigin).setPlayerRb(this.GetComponent<Rigidbody>());
        _animator = this.GetComponent<Animator>();
        _soundMananger = new SoundMananger();
        _animatorController = new AnimatorController(_animator);
        _playerView = new PlayerView(this, _animatorController, _soundMananger);
        _movement = new Movement(this, _animator, cam);
        _battleMechanics = new BattleMechanics(this, activeWeapon, grenades, _animator);
        _control = new PlayerController(this, _movement, _battleMechanics, _playerView);
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

    public void Subscribe(IObserver obs)
    {
        throw new System.NotImplementedException();
    }

    public void Unsubscribe(IObserver obs)
    {
        throw new System.NotImplementedException();
    }

    public void NotifyToObservers(string action)
    {
        throw new System.NotImplementedException();
    }

    public bool shooting
    {
        get { return isShooting; }
        set { isShooting = value; }
    }

    //public void Die()
    //{
    //    _animator.SetTrigger("Death");
    //    _animator.SetLayerWeight(_animator.GetLayerIndex("Shoot"), 0); 
    //}
}

