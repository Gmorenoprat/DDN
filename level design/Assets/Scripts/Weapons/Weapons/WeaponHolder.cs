using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder 
{
    private Player _player;
    public List<Weapon> weaponHolder = new List<Weapon>();
    public Weapon _activeWeapon;

    public WeaponHolder(Player player, Weapon activeWeapon) {
        _player = player;
        _activeWeapon = activeWeapon;

       
        weaponHolder[0] = _activeWeapon;
    }
    internal void ChangeWeapon(int slotPos)
    {
        _player.SetActiveWeapon = weaponHolder[slotPos];
    }

    public void AddWeapon(Weapon weapon) {
        if (weapon.IsPrimary)
        {
            weaponHolder[0] = weapon;
        }
        else if( ! weapon.IsPrimary)
        {
            weaponHolder[1] = weapon;
        }
    }

    public string arrayDeArmas()
    {
        string s = "";
        foreach(Weapon w in weaponHolder)
        {
            s += w.name + " ";
        }
        return s;
    }
}
