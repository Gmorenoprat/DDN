using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenades : MonoBehaviour, IObservable
{
    public float range = 30f;
    
    public Transform spawnPosition;
    public Rigidbody playerRb;

    public Grenade[] granadesHolder;
    private int[] _grenadeHolderCounter = new int[4] { 3,3,3,3}; //Crear seter
    private int _granadeSelected = 0;
    public Grenade _activeGranade;
    public int[] grenadeCount;
    
    List<IObserver> _allObserver = new List<IObserver>();


    #region Propiedades
    public int activeGranade { get { return _granadeSelected; } set { _granadeSelected = value; } }
    public int[] grenadeHolder { get { return _grenadeHolderCounter; } set { _grenadeHolderCounter = value; } }

    public float setRange { get; set; }

    //public Transform setSpwnPos { set { spawnPosition = value; } }

    //public Rigidbody setPlyrRB { set { playerRb = value; } }
    #endregion

    #region BUILDER
    public Grenades setSpawnPos(Transform transform)
    {
        spawnPosition.position = transform.position;
        spawnPosition.rotation = transform.rotation;
        return this;
    }
    public Grenades setPlayerRb(Rigidbody rb)
    {
        playerRb = rb;
        return this;
    }
    #endregion
    public void Start()
    {
        NotifyToObservers("UpdateGranade");
    }
    public void Launch()
    {
        if (_grenadeHolderCounter[_granadeSelected] == 0) return;
        _grenadeHolderCounter[_granadeSelected]--;
        Grenade nadeInstance = GrenadeSpawner.Instance.fragPool.GetObject().setSpawnPosition(spawnPosition);// Instantiate(granadesHolder[_granadeSelected], spawnPosition.position, spawnPosition.rotation);
        nadeInstance.Launch(playerRb.velocity);
        NotifyToObservers("UpdateGranade");
    }
    public void ChangeNadeType()
    {
        _granadeSelected = _granadeSelected++ % granadesHolder.Length; 
    }

    #region IObservable
    public void NotifyToObservers(string action)
    {

        for (int i = _allObserver.Count - 1; i >= 0; i--)
        {
            _allObserver[i].Notify(action);
        }
    }

    public void Subscribe(IObserver obs)
    {
        if (!_allObserver.Contains(obs))
        {
            _allObserver.Add(obs);
        }
    }

    public void Unsubscribe(IObserver obs)
    {
        if (_allObserver.Contains(obs))
        {
            _allObserver.Remove(obs);
        }
    }
    #endregion
}


