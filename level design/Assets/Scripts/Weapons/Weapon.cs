using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Ammo ammo;
    public Bullet bullet;
    public float realoadTime;
    public Transform bulletOrigin;

    IFiringMode myCurrentFiringMode;
    IFiringMode FMSingleShoot;
    IFiringMode FMBurstShoot;
    IFiringMode FMAutomaticShoot;

    FiringMode currentFiringMode;

    Coroutine shooting;
    Action shoot;
    void Awake()
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
        if (tipo == FiringMode.BURSTSHOOT) { myCurrentFiringMode = FMBurstShoot; }
        if (tipo == FiringMode.AUTOSHOOT) {myCurrentFiringMode = FMAutomaticShoot; }
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
    public Transform BulletOrigin
    {
        set { bulletOrigin = value; }
    }

    void ShootOne()
    {
       Bullet b = BulletSpawner.Instance.pool.GetObject().SetPosition(bulletOrigin);
    }

}

public struct Ammo
{
    public float AMMO;
    public float MAX_LOADED_AMMO;
    public int CLIPS;
}

public enum FiringMode
{
    SINGLESHOOT,
    BURSTSHOOT,
    AUTOSHOOT
}
