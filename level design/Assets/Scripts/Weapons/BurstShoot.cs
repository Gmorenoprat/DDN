using UnityEngine;
using System;

internal class BurstShoot :  IFiringMode
{
    private Bullet bullet;
    private Transform _bulletOrigin;

    public BurstShoot(Bullet bullet, Transform bulletOrigin)
    {
        this.bullet = bullet;
        _bulletOrigin = bulletOrigin;
    }

    public void Shoot(Action shoot)
    {
        shoot();
        Debug.Log("BURSTSHOOT");

    }
}