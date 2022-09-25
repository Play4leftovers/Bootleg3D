using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponArm : MonoBehaviour
{
    public Transform Cam;
    void Start()
    {
        
    }


    void Update()
    {
        transform.rotation = Quaternion.Euler(Cam.transform.eulerAngles.x, Cam.transform.eulerAngles.y, 0f);
    }
}
