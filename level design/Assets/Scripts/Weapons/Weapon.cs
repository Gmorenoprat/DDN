using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IObservable

{
    public Ammo ammo;
    public Bullet bullet;
    public float realoadTime;
    public Transform bulletOrigin;

    protected IFiringMode myCurrentFiringMode;
    protected IFiringMode FMSingleShoot;
    protected IFiringMode FMBurstShoot;
    protected IFiringMode FMAutomaticShoot; 

    FiringMode currentFiringMode;

    Coroutine shooting;
    Action shoot;

    List<IObserver> _allObserver = new List<IObserver>();

    public event Action<Ammo> onUpdateAmmo;

    public Ammo GetAmmo { get { return ammo; } }
    public Transform BulletOrigin{ get { return bulletOrigin; } private set { bulletOrigin = value; }    }


    protected virtual void Awake()
    {
        FMSingleShoot = new SingleShoot();
        FMBurstShoot =  new BurstShoot();
        FMAutomaticShoot = new AutomaticShoot();

        shoot += ShootOne;

    }

     public void ChangeFiringMode(FiringMode tipo)
    {
        currentFiringMode = tipo;
        if (tipo == FiringMode.SINGLESHOOT) { myCurrentFiringMode = FMSingleShoot; }
        else if (tipo == FiringMode.BURSTSHOOT) { myCurrentFiringMode = FMBurstShoot; }
        else if (tipo == FiringMode.AUTOSHOOT) {myCurrentFiringMode = FMAutomaticShoot; }
    }

    internal FiringMode getCurrentFireMode()
    {
        return currentFiringMode;
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
        //NotifyToObservers("UpdateAmmo");

    }


    //INICIAR CORUTINA DE RELOAD TIME
    public void Reload()
    {
        if (ammo.CLIPS == 0) return;
        ammo.AMMO = ammo.MAX_LOADED_AMMO;
        ammo.CLIPS--;
        NotifyToObservers("UpdateAmmo");
    }


    public void NotifyToObservers(string action)
    {

        for (int i = _allObserver.Count - 1; i >= 0; i--)
        {
            _allObserver[i].Notify(action);
        }
    }

    public void Subscribe(IObserver obs)
    {
        if (!_allObserver.Contains(obs))
        {
            _allObserver.Add(obs);
        }
    }

    public void Unsubscribe(IObserver obs)
    {
        if (_allObserver.Contains(obs))
        {
            _allObserver.Remove(obs);
        }
    }
}

public struct Ammo
{
    public int AMMO;
    public int MAX_LOADED_AMMO;
    public int CLIPS;
}

public enum FiringMode
{
    SINGLESHOOT,
    BURSTSHOOT,
    AUTOSHOOT
}
