using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Ammo ammo;
    public Bullet bullet;
    protected float realoadTime;
    private Transform _bulletOrigin;

    IFiringMode myCurrentFiringMode;
    IFiringMode FMSingleShoot;
    IFiringMode FMBurstShoot;
    IFiringMode FMAutomaticShoot;
    void Awake()
    {
        FMSingleShoot = new SingleShoot(bullet,_bulletOrigin);
        FMBurstShoot =  new BurstShoot(bullet,_bulletOrigin);
        FMAutomaticShoot = new AutomaticShoot(bullet,_bulletOrigin);

    }
    public void Shoot()
    {
        Debug.Log("entraAca");
        if(myCurrentFiringMode != null) myCurrentFiringMode.Shoot();
    }

    public void ChangeFiringMode(FiringMode tipo)
    {
        if (tipo == FiringMode.SINGLESHOOT) myCurrentFiringMode = FMSingleShoot;
        if (tipo == FiringMode.BURSTSHOOT) myCurrentFiringMode = FMBurstShoot;
        if (tipo == FiringMode.AUTOSHOOT) myCurrentFiringMode = FMAutomaticShoot;
    }
    public Transform BulletOrigin
    {
        set { _bulletOrigin = value; }
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
