﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder 
{
    private Player _player;
    public Weapon _primaryWeapon;
    public Weapon _secondaryWeapon;

    public event Action<Weapon> onUpdateWeapon;


    public WeaponHolder(Player player) {
        _player = player;
    }
    internal void ChangeWeapon(int slotPos)
    {
        if(slotPos == 1 && _primaryWeapon)
        {
            _player.ActiveWeapon = _primaryWeapon;
            onUpdateWeapon(_primaryWeapon);
        }
        else if(slotPos == 2 && _secondaryWeapon)
        {
            _player.ActiveWeapon = _secondaryWeapon;
            onUpdateWeapon(_secondaryWeapon);

        }
        
    }

    public void AddWeapon(Weapon weapon) {
        if (weapon.IsPrimary)
        {
            _primaryWeapon = weapon;
        }
        else if( ! weapon.IsPrimary)
        {
            _secondaryWeapon = weapon;
        }
    }

    //TEST
    public string arrayDeArmas()
    {
        string s = "";
        s += "ArmaPrimaria = " + _primaryWeapon.Name;
        s += "\n ArmaSecundaria = " + _secondaryWeapon.Name;
        return s;
    }
}
