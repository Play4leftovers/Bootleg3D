using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponArm : MonoBehaviour
{
    public Transform Cam;

    GameObject CurrentGun;

    [SerializeField] GameObject StartingGun;

    [SerializeField] PlayerInput _playerInput;
    private InputAction _shootAction;
    //private InputAction _switchAction;

    private void Awake()
    {
        //_switchAction = _playerInput.actions["WeaponSwitch"];
        _shootAction = _playerInput.actions["Shoot"];
        UpdateWeapon(StartingGun);
    }
    private void Update()
    {
        if (GetComponentInParent<W�rmController>().Moving == false && GetComponentInParent<W�rmController>().Active == true)
        {
            transform.rotation = Quaternion.Euler(Cam.transform.eulerAngles.x, Cam.transform.eulerAngles.y, 0f);
        }
    }

    void Shoot()
    {
        if (GetComponentInParent<W�rmController>().Moving == false && GetComponentInParent<W�rmController>().Active == true)
        {
            CurrentGun.GetComponent<WeaponFire>().Fire();
        }
    }
    public void UpdateWeapon(GameObject _weapon)
    {
        Destroy(CurrentGun);
        CurrentGun = Instantiate(_weapon, this.transform.position, this.transform.rotation, this.transform);
    }

    private void OnEnable()
    {
        _shootAction.performed += _ => Shoot();
    }
}
