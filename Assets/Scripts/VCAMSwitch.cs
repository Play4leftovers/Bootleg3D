using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class VCAMSwitch : MonoBehaviour
{
    [SerializeField] PlayerInput _playerInput;
    private InputAction _aimAction;

    private CinemachineVirtualCamera _virtualCamera;

    [SerializeField] int _priorityBoost = 10;


    private void Awake()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        _aimAction = _playerInput.actions["Aim"];
    }

    private void OnEnable()
    {
        _aimAction.performed += _ => StartAim();
        _aimAction.canceled += _ => CancelAim();
    }
    private void OnDisable()
    {
        _aimAction.performed -= _ => StartAim();
        _aimAction.canceled -= _ => CancelAim();
    }
    private void StartAim()
    {
        _virtualCamera.Priority += _priorityBoost;
    }
    private void CancelAim()
    {
        _virtualCamera.Priority -= _priorityBoost;
    }
}
