using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    public GameObject BulletPrefab;
    public void Fire()
    {
        GameObject Missile = Instantiate(BulletPrefab, transform.GetChild(0).position, transform.rotation);
        Missile.GetComponent<Rigidbody>().AddForce(Missile.transform.up * 1000);
    }
}
