using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder 
{
    public Weapon[] weaponHolder = new Weapon[2];
    public Weapon _activeWeapon;

    public WeaponHolder(ref Weapon activeWeapon) {
        _activeWeapon = activeWeapon;
    }
    internal void ChangeWeapon(int slotPos)
    {
        _activeWeapon = weaponHolder[slotPos];
    }
}
