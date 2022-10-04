using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] int ImpactDamage = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<WörmStats>().TakeDamage(ImpactDamage);
            Destroy(gameObject);
        }
        if (!other.CompareTag("Pellet"))
        {
            Destroy(gameObject);
        }
    }
}
