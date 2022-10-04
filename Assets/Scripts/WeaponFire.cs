using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public float FiringForce;
    public void Fire()
    {
        GameObject Missile = Instantiate(ProjectilePrefab, transform.GetChild(0).position, transform.rotation);
        Missile.GetComponent<Rigidbody>().AddForce(Missile.transform.forward * FiringForce);
    }
}
