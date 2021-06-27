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

    Action shoot;
    void Awake()
    {
        FMSingleShoot = new SingleShoot(bullet, bulletOrigin);
        FMBurstShoot =  new BurstShoot(bullet, bulletOrigin);
        FMAutomaticShoot = new AutomaticShoot(bullet, bulletOrigin);

        shoot += ShootOne;

    }
    public void ChangeFiringMode(FiringMode tipo)
    {
        if (tipo == FiringMode.SINGLESHOOT) myCurrentFiringMode = FMSingleShoot;
        if (tipo == FiringMode.BURSTSHOOT) myCurrentFiringMode = FMBurstShoot;
        if (tipo == FiringMode.AUTOSHOOT) myCurrentFiringMode = FMAutomaticShoot;
    }

    public void Shoot()
    {
        if(myCurrentFiringMode != null) myCurrentFiringMode.Shoot(shoot);
    }


    public Transform BulletOrigin
    {
        set { bulletOrigin = value; }
    }

    private void ShootOne()
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
