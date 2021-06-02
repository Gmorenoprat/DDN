using UnityEngine;

public class BattleMechanics 
{
    Player _player;
    Bullet _bullet;
    Transform _bulletOrigin;
    Weapon _weapon;
    Animator _animator;
    public BattleMechanics(Player p, Weapon w, Animator a)
    {
        _player = p;
        _bullet = _player.bullet;
        _bulletOrigin = _player.bulletOrigin;
        _animator = a;
        _weapon = w;
        //_rb = _player.GetComponent<Rigidbody>();
    }

    public void Shoot()
    {
        _weapon.Shoot();
        _animator.SetTrigger("Shoot"); 
    }

    public void ChangeWeapon(Weapon w)
    {
        _weapon = w;
    }

    public void ChangeFiringMode(FiringMode FM)
    {
        _weapon.ChangeFiringMode(FM);
    }
}
