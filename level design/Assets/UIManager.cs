using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Image[] Bull;
    public Sprite FullBull;
    public Sprite EmptyBull;


    //IObservable _Weapon;
    //IObservable _Grenades;
    Player _player;
    Weapon ActiveWeapon;
    WeaponHolder wepHolder;
    GrenadeHolder ActiveGrenades;

    public Text life;
    public Text ammo;
    public Text MaxAmmo;
  
    public Text Granade;

    private void Start()
    {
        _player = this.GetComponent<Player>();
        ActiveWeapon = _player.ActiveWeapon;
        wepHolder = _player.weaponHolder;
        ActiveGrenades = _player.ActiveGrenades;

        UpdateAmmoCount(ActiveWeapon.GetAmmo);
        UpdateGranadeCount(ActiveGrenades.grenadeHolder);


        _player.onUpdateLife += LifeUpdate;
        ActiveWeapon.onUpdateAmmo += UpdateAmmoCount;
        wepHolder.onUpdateWeapon += WeaponChanged;
        ActiveGrenades.onUpdateCount += UpdateGranadeCount;

    }

    public void UpdateAmmoCount(Ammo ammo)
    {
        this.ammo.text = ammo.AMMO.ToString();  
        MaxAmmo.text = "/"+(ActiveWeapon.GetAmmo.MAX_LOADED_AMMO * ActiveWeapon.GetAmmo.CLIPS).ToString();
    }

    public void WeaponChanged(Weapon wep)
    {
        ActiveWeapon = wep;
        UpdateAmmoCount(wep.GetAmmo);
        ActiveWeapon = _player.ActiveWeapon;
        ActiveWeapon.onUpdateAmmo += UpdateAmmoCount;

    }
    public void LifeUpdate(float life){
        this.life.text = life.ToString();
    }

    public void UpdateGranadeCount(int[] grenadeCount)
    {
      Granade.text = grenadeCount[0].ToString();
    }

}
