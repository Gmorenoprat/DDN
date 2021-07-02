using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragNade : Grenade
{
    private void Start()
    {
        grenadeType = GrenadeType.FRAG_NADE;
    }

    protected override void Explode()
    {
        Collider[] collection = Physics.OverlapSphere(transform.position, explosionDistance, mask);

        foreach (var item in collection)
        {
            var rb = item.GetComponent<Rigidbody>();

            if (rb != null)
            {
                var distace = (item.transform.position - transform.position);//for damage?
                rb.AddExplosionForce(force, transform.position, explosionDistance, 1f, ForceMode.Impulse);
            }

        }
        FXSpawner.Instance.fragPool.GetObject().SetPosition(this.transform);
        GrenadeSpawner.Instance.ReturnGrenade(this);
    }
}

