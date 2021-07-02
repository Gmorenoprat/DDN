using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX : MonoBehaviour
{
    public Transform fxTransform;

    public FXType fxType;

    public float lifeTime = 5f;

    private void Awake()
    {
        fxTransform = this.GetComponent<Transform>();
    }

    private void OnEnable()
    {
        Invoke("returnFX",lifeTime);
    }

    private void returnFX()
    {
        FXSpawner.Instance.ReturnFX(this);
    }

    public FX SetPosition(Transform t)
    {
        fxTransform.position = t.position;
        fxTransform.forward = -t.forward;
        return this;
    }

    public static void TurnOn(FX fx)
    {
        fx.gameObject.SetActive(true); 
    }

    public static void TurnOff(FX fx)
    {
        fx.gameObject.SetActive(false); 

    }

    public enum FXType
    {
        FRAG_EXPLOTION,
        FLASH_EXPLOTION
    }
}
