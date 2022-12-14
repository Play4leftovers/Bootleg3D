using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosionEffect;
    public float ExplosionRange = 500.0f;
    public float Damage = 50;
    private void Start()
    {

        Collider[] Hits = Physics.OverlapSphere(transform.position, ExplosionRange);
        foreach (Collider _nearbyObjects in Hits)
        {
            W?rmStats _stats = _nearbyObjects.GetComponent<W?rmStats>();
            if(_stats != null)
            {
                _stats.TakeDamage((int)(Damage / (Vector3.Distance(_stats.gameObject.transform.position, transform.position))));
            }
        }
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
