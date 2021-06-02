using UnityEngine;

internal class AutomaticShoot : IFiringMode
{
    private Bullet bullet;
    private Transform _bulletOrigin;

    public AutomaticShoot(Bullet bullet, Transform bulletOrigin)
    {
        this.bullet = bullet;
        _bulletOrigin = bulletOrigin;
    }

    public void Shoot()
    {
     
        Debug.Log("AUTOSHOOT");

    }
}