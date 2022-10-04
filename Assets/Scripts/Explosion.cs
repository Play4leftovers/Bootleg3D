using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosionEffect;
    public float ExplosionRange = 5.0f;
    public float Damage = 50;
    private void Awake()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] Hits = Physics.OverlapSphere(transform.position, ExplosionRange);
        foreach (Collider _nearbyObjects in Hits)
        {
            WörmStats _stats = _nearbyObjects.GetComponent<WörmStats>();
            if(_stats != null)
            {
                _stats.TakeDamage((int)(Damage / (Vector3.Distance(_stats.gameObject.transform.position, transform.position))));
            }
        }

        Destroy(gameObject);
    }
}
