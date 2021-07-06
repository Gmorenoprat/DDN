using System;
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
    public WeaponHolder weaponHolder;


    public Transform grenadeOrigin;
    public GrenadeHolder grenades;

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
    public Camera cam;

    public Weapon ActiveWeapon{ get { return activeWeapon; } set { activeWeapon = value; } }  //SET AND RELOAD

    public GrenadeHolder ActiveGrenades{ get { return grenades; } set { grenades = value; } }

    //Debug pourpuse
    public Transform CtSpawn;
    public Transform MafiaSpawn;

    private void Start()
    {
        _control = new PlayerController(this);
        _animator = this.GetComponent<Animator>();

        cam = Camera.main;
        _soundMananger = new SoundMananger();
        _animatorController = new AnimatorController(_animator);
        _playerView = new PlayerView(this, _animatorController, _soundMananger);
        _movement = new Movement(this, cam);

        activeWeapon.BulletOrigin = bulletOrigin;
        grenades = new GrenadeHolder().setSpawnPos(grenadeOrigin).setPlayerRb(this.GetComponent<Rigidbody>());

        weaponHolder = new WeaponHolder(this,activeWeapon);

        weaponHolder.AddWeapon(activeWeapon);
        weaponHolder.AddWeapon(new Deagle());
        _battleMechanics = new BattleMechanics(this, activeWeapon, weaponHolder, grenades);
    }


    void Update()
    {
        _control.OnUpdate();

        //FORDEBUG
        //if (Input.GetKeyDown(KeyCode.F1)) { this.transform.position = CtSpawn.position; }
        //if (Input.GetKeyDown(KeyCode.F2)) { this.transform.position = MafiaSpawn.position; }  

        if (Input.GetKeyDown(KeyCode.U)) { Debug.Log(activeWeapon.Name); }
        if (Input.GetKeyDown(KeyCode.L)) { Debug.Log(weaponHolder.arrayDeArmas()); }
    }


    #region LIFE_STUFF
    public void GetDamage(float dmg)
    {
        life -= dmg;
    }
    
    //public void Die()
    //{
    //    _animator.SetTrigger("Death");
    //    _animator.SetLayerWeight(_animator.GetLayerIndex("Shoot"), 0); 
    //}
    #endregion

    #region MOVEMENT
    internal void Aim()
    {
        _movement.Aim();
    }
    internal void Move(float v, float h)
    {
        _movement.Move(v, h);
        _playerView.animator.Move(h,v);
    }
    internal void Roll()
    {
        _movement.Roll();
        _playerView.animator.Roll();
    }
    internal void ChangeMovementMode(MovementMode mm)
    {
        _movement.ChangeMovementMode(mm);
    }

    #endregion

    #region BATTLE_MECHANICS
    public bool shooting
    {
        get { return isShooting; }
        set { isShooting = value; }
    }

    public Weapon SetActiveWeapon { get { return activeWeapon; } set { activeWeapon = value; } }

    internal void Shoot()
    {
        _battleMechanics.Shoot();
    }
    internal void StopShoot()
    {
        _battleMechanics.StopShoot();
    }
    internal void ReloadActiveWeapon()
    {
        _battleMechanics.ReloadActiveWeapon();
    }
    internal void ChangeFiringMode()
    {
        _battleMechanics.ChangeFiringMode();
    }
    internal void ChangeWeapon(int slotPos)
    {
        _battleMechanics.ChangeWeapon(slotPos);
    }

    internal void changeGranade()
    {
        _battleMechanics.changeGranade();        
    }
    internal void launchGranade()
    {
        _battleMechanics.launchGranade();
    }

    #endregion

    #region IOBSERVER
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

    #endregion
}

