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

    protected IFiringMode myCurrentFiringMode;
    protected IFiringMode FMSingleShoot;
    protected IFiringMode FMBurstShoot;
    protected IFiringMode FMAutomaticShoot;

    protected IFiringMode[] availablesFiringModes;

    private int _currentMode = 0;

    private bool _isPrimary = true;
    private string _name;
    
    Coroutine shooting;
    Action shoot;

    List<IObserver> _allObserver = new List<IObserver>(); 

    public event Action<Ammo> onUpdateAmmo;

    public Action changeFiringMode;

    public Ammo GetAmmo { get { return ammo; } }
    public Transform BulletOrigin{ get { return bulletOrigin; } set { bulletOrigin = value; }    }

    public bool IsPrimary { get { return _isPrimary; } set { _isPrimary = value; } }
    public string Name { get { return _name; } set { _name = value; } }

    protected virtual void Awake()
    {
        FMSingleShoot = new SingleShoot();
        FMBurstShoot =  new BurstShoot();
        FMAutomaticShoot = new AutomaticShoot();
        
        shoot += ShootOne;
        changeFiringMode += ChangeFiringMode;

    }

    public void ChangeFiringMode()
    {
        _currentMode++;
        myCurrentFiringMode = availablesFiringModes[_currentMode%(availablesFiringModes.Length)];
    }

    public void Shoot()
    {
        if (myCurrentFiringMode != null) shooting = StartCoroutine(myCurrentFiringMode.Shoot(shoot));
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


    //INICIAR CORUTINA DE RELOAD TIME
    public void Reload()
    {
        if (ammo.CLIPS == 0) return;
        ammo.AMMO = ammo.MAX_LOADED_AMMO;
        ammo.CLIPS--;
        onUpdateAmmo(ammo);
    }

    //IOBSERVER: DEPRECATED
    //public void NotifyToObservers(string action)
    //{

    //    for (int i = _allObserver.Count - 1; i >= 0; i--)
    //    {
    //        _allObserver[i].Notify(action);
    //    }
    //}

    //public void Subscribe(IObserver obs)
    //{
    //    if (!_allObserver.Contains(obs))
    //    {
    //        _allObserver.Add(obs);
    //    }
    //}

    //public void Unsubscribe(IObserver obs)
    //{
    //    if (_allObserver.Contains(obs))
    //    {
    //        _allObserver.Remove(obs);
    //    }
    //}
}

public struct Ammo
{
    public int AMMO;
    public int MAX_LOADED_AMMO;
    public int CLIPS;
}

