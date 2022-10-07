using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponArm : MonoBehaviour
{
    public Transform Cam;

    public bool Fired = false;

    GameObject _currentGun; 
    [SerializeField] GameObject[] _currentGunList = new GameObject[2];
    public bool _gunNumber = true;

    [SerializeField] PlayerInput _playerInput;
    private InputAction _shootAction;
    private InputAction _switchAction;

    private void Awake()
    {
        _switchAction = _playerInput.actions["WeaponSwitch"];
        _shootAction = _playerInput.actions["Shoot"];
        UpdateWeapon(_currentGunList[0]);
        
    }
    private void Start()
    {
        Cam = GetComponentInParent<WörmController>().Cam;
    }
    public void UpdateCam()
    {
        Cam = GetComponentInParent<WörmController>().Cam;
    }
    private void Update()
    {
        if (GetComponentInParent<WörmController>().Moving == false && GetComponentInParent<WörmController>().Active == true)
        {
            transform.rotation = Quaternion.Euler(Cam.transform.eulerAngles.x, Cam.transform.eulerAngles.y, 0f);
        }
    }

    void Shoot()
    {
        if (GetComponentInParent<WörmController>().Moving == false && GetComponentInParent<WörmController>().Active == true && Fired == false)
        {
            _currentGun.GetComponent<WeaponFire>().Fire();
            Fired = true;
        }
    }
    void Switch()
    {
        
        if(_gunNumber == false)
        {
            UpdateWeapon(_currentGunList[0]);
            _gunNumber = true;
        }
        else
        {
            UpdateWeapon(_currentGunList[1]);
            _gunNumber = false;
        }
    }
    public void UpdateWeapon(GameObject _weapon)
    {
        Destroy(_currentGun);
        _currentGun = Instantiate(_weapon, this.transform.position, this.transform.rotation, this.transform);
    }

    private void OnEnable()
    {
        _shootAction.performed += _ => Shoot();
        _switchAction.performed += _ => Switch();
    }
}
