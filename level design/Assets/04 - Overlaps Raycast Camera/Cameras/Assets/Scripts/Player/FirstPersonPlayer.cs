using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonPlayer : Player
{
    void Update()
    {
        if (canUse && Input.GetMouseButtonDown(0))
            gun.Shoot();
    }
}
