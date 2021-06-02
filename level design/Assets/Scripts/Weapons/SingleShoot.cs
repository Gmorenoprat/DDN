using UnityEngine;

public class SingleShoot : IFiringMode
{
    private Bullet bullet;
    private Transform _bulletOrigin;

    public SingleShoot(Bullet bullet, Transform bulletOrigin)
    {
        this.bullet = bullet;
        _bulletOrigin = bulletOrigin;
    }

    public void Shoot()
    {


        Debug.Log("SINGLESHOOT");
    }
}