using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdpersonPlayer : Player
{
    private Animator _anim;
    public Bullet bullet;
    public Transform bulletOrigin;

    protected override void Awake()
    {
        base.Awake();

        _anim = GetComponent<Animator>(); //Guardo mi animator
    }

    void Update()
    {
        _anim.SetFloat("Speed_Forward", Input.GetAxis("Vertical")); //Seteo float en el animator    
        _anim.SetFloat("Speed_Right", Input.GetAxis("Horizontal")); //Seteo float en el animator                             

        if (Input.GetKeyDown(KeyCode.LeftControl))
            _anim.SetBool("Crouched", true); //Seteo bool en el animator
        if (Input.GetKeyUp(KeyCode.LeftControl))
            _anim.SetBool("Crouched", false);

        if (canUse && Input.GetMouseButtonDown(0)) { 
            _anim.SetTrigger("Shoot"); //Seteo un trigger en el animator
            Bullet b = Instantiate(bullet);
            b.transform.position = bulletOrigin.position;
            b.transform.forward = bulletOrigin.transform.forward;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            _anim.SetTrigger("Death");
            _anim.SetLayerWeight(_anim.GetLayerIndex("Shoot"), 0); //Asigno peso 0 a al Layer "Shoot" asi no se puede usar mas
        }
    }

    public void Shoot()
    {
        gun.Shoot(); //La clase Gun como hereda de IShoot, puedo llamar la funcion Shoot
    }
}
