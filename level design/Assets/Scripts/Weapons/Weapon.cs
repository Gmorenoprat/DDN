using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour

{
    protected Ammo ammo;
    protected Bullet bullet;
    protected float realoadTime;
    protected Transform bulletOrigin;
    protected Transform[] bulletOriginBucket;

    protected IFiringMode myCurrentFiringMode;
    protected IFiringMode FMSingleShoot;
    protected IFiringMode FMBurstShoot;
    protected IFiringMode FMAutomaticShoot;
    protected IFiringMode FMBuckShoot;

    protected IFiringMode[] availablesFiringModes;

    private int _currentMode = 0;

    private bool _isPrimary;
    private string _name;
    
    Coroutine shooting;
    Action shoot;

    //List<IObserver> _allObserver = new List<IObserver>(); 

    public event Action<Ammo> onUpdateAmmo;

    public Action changeFiringMode;

    public Ammo GetAmmo { get { return ammo; } }
    public Transform BulletOrigin{ get { return bulletOrigin; } set { bulletOrigin = value; }    }
    public Transform[] BulletOriginBucket{ get { return bulletOriginBucket; } set { bulletOriginBucket = value; }    }

    public bool IsPrimary { get { return _isPrimary; } set { _isPrimary = value; } }
    public string Name { get { return _name; } set { _name = value; } }

    protected virtual void Awake()
    {
        FMSingleShoot = new SingleShoot();
        FMBurstShoot =  new BurstShoot();
        FMAutomaticShoot = new AutomaticShoot();
        FMBuckShoot = new BuckShoot();
        
        shoot += ShootOne;
        changeFiringMode += ChangeFiringMode;

    }

    //TODO: Sacar a obj externo (IInteractive)
    private void OnTriggerStay(Collider other)
    {
        if (!other.GetComponent<Player>()) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Player _player = other.GetComponent<Player>();
            _player.GrabWeapon(this);
            bulletOrigin = _player.bulletOrigin;
            bulletOriginBucket = _player.bulletOriginBucket;
        }
    }
    public void ChangeFiringMode()
    {
        _currentMode++;
        myCurrentFiringMode = availablesFiringModes[_currentMode%(availablesFiringModes.Length)];
    }
    public void ChangeFiringType(FiringType ft)
    {
        if (ft == FiringType.SINGLESHOOT) shoot = ShootOne;
        else if (ft == FiringType.BUCKETSHOOT) shoot = ShootBuck;
    }

    public void Shoot()
    {
        if (myCurrentFiringMode != null)
        {
            shooting = StartCoroutine(myCurrentFiringMode.Shoot(shoot));
        }
    }

    public void StopShoot()
    {
        
        StopCoroutine(shooting);
    }

    void ShootOne()
    {
        if (ammo.AMMO <= 0) return;

        Bullet b = BulletSpawner.Instance.pool.GetObject().SetPosition(bulletOrigin);
        ammo.AMMO--;
        onUpdateAmmo(ammo);


    }
    void ShootBuck()
    {
        if (ammo.AMMO <= 0) return;
        ammo.AMMO--;
        onUpdateAmmo(ammo);


        foreach (Transform t in BulletOriginBucket)
        {
            BulletSpawner.Instance.pool.GetObject().SetPosition(t);
        }


    }


    //INICIAR CORUTINA DE RELOAD TIME
    public void Reload()
    {
        if (ammo.CLIPS == 0) return;
        ammo.AMMO = ammo.MAX_LOADED_AMMO;
        ammo.CLIPS--;
        onUpdateAmmo(ammo);
    }

}

public struct Ammo
{
    public int AMMO;
    public int MAX_LOADED_AMMO;
    public int CLIPS;
}

public enum FiringType
{
    SINGLESHOOT,
    BUCKETSHOOT,
}

