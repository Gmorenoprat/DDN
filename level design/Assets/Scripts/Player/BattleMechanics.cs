using UnityEngine;

public class BattleMechanics 
{
    Player _player;
    Bullet _bullet;
    Transform _bulletOrigin;
    Animator _animator;
    public BattleMechanics(Player p, Animator a)
    {
        _player = p;
        _bullet = _player.bullet;
        _bulletOrigin = _player.bulletOrigin;
        _animator = a;
        //_rb = _player.GetComponent<Rigidbody>();
    }

    public void Shoot()
    {
        _player.Shoot();
        _animator.SetTrigger("Shoot"); 
    }
}
