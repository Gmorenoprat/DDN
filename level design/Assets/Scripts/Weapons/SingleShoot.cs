using UnityEngine;
using System;

public class SingleShoot : IFiringMode
{
    private Bullet bullet;
    private Transform _bulletOrigin;

    public SingleShoot(Bullet bullet, Transform bulletOrigin)
    {
        this.bullet = bullet;
        _bulletOrigin = bulletOrigin;
    }

    public void Shoot(Action shoot)
    {
        shoot();
        Debug.Log("SINGLESHOOT");
    }
}