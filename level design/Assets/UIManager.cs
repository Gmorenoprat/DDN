using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IObserver
{
    public int Life;
    public int NumberOfBull;
    public Image[] Bull;
    public Sprite FullBull;
    public Sprite EmptyBull;
   

    IObservable _Weapon;
    Weapon ActiveWeapon;
    
    public Text AmmonRifle;
    public Text MaxAmmo;
  
    public Text Granade;
    public Text MaxGranade;

    private void Awake()
    {
        ActiveWeapon = this.GetComponent<Player>().ActiveWeapon;
        _Weapon = this.GetComponent<Player>().ActiveWeapon;
        _Weapon.Subscribe(this);
    }
    private void Start()
    {
       
       
        UpdateAmmo();

    }

   public void UpdateAmmo()
    {
        if (NumberOfBull <= 0) return;
        MaxAmmo.text = "/"+(ActiveWeapon.GetAmmo.MAX_LOADED_AMMO * ActiveWeapon.GetAmmo.CLIPS).ToString();
        AmmonRifle.text = ActiveWeapon.GetAmmo.AMMO.ToString();  
        NumberOfBull = ActiveWeapon.GetAmmo.AMMO;
    }
    public void reload()
    {
        if (NumberOfBull < 1) NumberOfBull = ActiveWeapon.GetAmmo.MAX_LOADED_AMMO;
        UpdateAmmo();
    }
    public void LifeUpdate()
    {

    }

    public void UpdateGranade()
    {

    }
    public void Notify(string action)
    {
        if (action=="UpdateAmmo")
        {
            UpdateAmmo();
        }
        if(action=="reload")
        {
            reload();
        }
        if (action=="LifeUpdate")
        {

        }
        if(action=="UpdateGranade")
        {

        }
    }
}
