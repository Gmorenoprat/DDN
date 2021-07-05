using UnityEngine;

public class BattleMechanics
{
    Player _player;
    Weapon _weapon;
    GrenadeHolder _grenades;
    public BattleMechanics(Player p, Weapon w, GrenadeHolder g)
    {
        _player = p;
        _weapon = w;
        _grenades = g;
    }

    public void Shoot()
    {
        _weapon.Shoot();
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
