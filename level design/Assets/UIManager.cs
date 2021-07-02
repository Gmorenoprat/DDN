using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IObserver
{
    public int Life;

    public Image[] Bull;
    public Sprite FullBull;
    public Sprite EmptyBull;
   

    //IObservable _Weapon;
    //IObservable _Grenades;
    Weapon ActiveWeapon;
    Grenades ActiveGrenades;
    
    public Text ammo;
    public Text MaxAmmo;
  
    public Text Granade;

    private void Start()
    {
        Player player = this.GetComponent<Player>();
        ActiveWeapon = player.ActiveWeapon;
        ActiveGrenades = player.ActiveGrenades;
        // _Weapon = player.ActiveWeapon;
        //_Grenades = player.ActiveGrenades;
        //  _Weapon.Subscribe(this);
        //_Grenades.Subscribe(this);

        ActiveWeapon.onUpdateAmmo += UpdateAmmoCount;
        UpdateGranadeCount();

     }

    public void UpdateAmmoCount(Ammo ammo)
    {
        this.ammo.text = ammo.AMMO.ToString();  
        MaxAmmo.text = "/"+(ActiveWeapon.GetAmmo.MAX_LOADED_AMMO * ActiveWeapon.GetAmmo.CLIPS).ToString();
    }

    public void LifeUpdate(){}

    public void UpdateGranadeCount()
    {
        Granade.text = ActiveGrenades.grenadeHolder[ActiveGrenades.activeGranade].ToString();
    }
    public void Notify(string action)
    {
        if (action== "UpdateAmmo")
        {
         //UpdateAmmoCount();
        }

        if (action=="LifeUpdate"){}

        if(action=="UpdateGranade")
        {
            UpdateGranadeCount();
        }
    }
}
