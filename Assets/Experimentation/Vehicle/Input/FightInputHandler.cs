using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightInputHandler : MonoBehaviour, IFightInput
{
    private CarControls _carControls;
    public event Action<float> MovementInputReceived;
    public event Action BrakeStartInputReceived;
    public event Action BrakeEndInputReceived;
    public event Action AttackInputReceived;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        _carControls = new CarControls();
        _carControls.Enable();
        _carControls.Vehicle.Brake.performed += _ => BrakeStartInputReceived?.Invoke();
        _carControls.Vehicle.Brake.canceled += _ => BrakeEndInputReceived?.Invoke();
        _carControls.Vehicle.Attack.performed += _ => AttackInputReceived?.Invoke();
    }

    private void OnDisable()
    {
        _carControls.Disable();
        _carControls.Vehicle.Brake.performed -= _ => BrakeStartInputReceived?.Invoke();
        _carControls.Vehicle.Brake.canceled -= _ => BrakeEndInputReceived?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        float _movementInput = _carControls.Vehicle.LeftRight.ReadValue<float>();
        if (_movementInput != 0)
        {
            MovementInputReceived?.Invoke(_movementInput);
        }
    }
}
