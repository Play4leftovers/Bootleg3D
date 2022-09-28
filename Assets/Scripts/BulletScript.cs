using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] int ImpactDamage;
    public GameObject Explosion;
    private void Start()
    {
        
    }

    private void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
