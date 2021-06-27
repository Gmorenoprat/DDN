using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : Weapon
{

    public void Start()
    {
        Ammo am = new Ammo();
        am.MAX_LOADED_AMMO = 30;
        am.AMMO = 30;
        am.CLIPS = 3;

        ammo = am;

        ChangeFiringMode(FiringMode.AUTOSHOOT);
    }

}
