using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponArm : MonoBehaviour
{
    public Transform Cam;
    public GameObject CurrentGun;
    void Start()
    {
        
    }


    void Update()
    {
        transform.rotation = Quaternion.Euler(Cam.transform.eulerAngles.x, Cam.transform.eulerAngles.y, 0f);
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        CurrentGun.GetComponent<WeaponFire>().Fire();
    }
}
