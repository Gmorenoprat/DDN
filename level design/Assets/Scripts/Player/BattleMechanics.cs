using UnityEngine;

public class BattleMechanics
{
    Player _player;
    Bullet _bullet;
    Transform _bulletOrigin;
    Weapon _weapon;
    Grenades _grenades;
    Animator _animator;
    public BattleMechanics(Player p, Weapon w, Grenades g, Animator a)
    {
        _player = p;
        _bullet = _player.bullet;
        _bulletOrigin = _player.bulletOrigin;
        _animator = a;
        _weapon = w;
        _grenades = g;
        //_rb = _player.GetComponent<Rigidbody>();
    }

    public void Shoot()
    {
        _weapon.Shoot();
        _animator.SetTrigger("Shoot"); 
    }

    public void StopShoot()
    {
        _weapon.StopShoot();
    }

    public void ChangeWeapon(Weapon w)
    {
        _weapon = w;
    }
    public void ReloadActiveWeapon()
    {
        _weapon.Reload();
    }

    public void ChangeFiringMode(FiringMode FM)
    {
        _weapon.ChangeFiringMode(FM);
    }

    public FiringMode getCurrentFireMode()
    {
        return _weapon.getCurrentFireMode();
    }

    public void launchGranade()
    {
        _grenades.Launch();
    }
    public void changeGranade()
    {
        _grenades.ChangeNadeType();
    }




}
