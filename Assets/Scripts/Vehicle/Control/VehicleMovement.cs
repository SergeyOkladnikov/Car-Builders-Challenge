using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class VehicleMovement : MonoBehaviour
{
    [SerializeField]
    private bool isBotControlled;
    [SerializeField]
    public int wheelSpeed = 400;
    [SerializeField]
    private IFightInput _inputHandler;
    [SerializeField]
    public WheelJoint2D[] wheels;
    void Start()
    {
    }

    private void OnEnable()
    {
        if (!isBotControlled)
        {
            _inputHandler = FindObjectOfType<FightInputHandler>();
        }
        else
        {
            _inputHandler = GetComponent<Bot>();
        }
        
        wheels = GetComponentsInChildren<WheelJoint2D>();
        _inputHandler.MovementInputReceived += Move;
        _inputHandler.BrakeStartInputReceived += EnableBrake;
        _inputHandler.BrakeEndInputReceived += DisableBrake;
        if (!isBotControlled)
        {
            Debug.Log(_inputHandler);
            Debug.Log(wheels);
        }
    }

    private void OnDisable()
    {
        _inputHandler.MovementInputReceived -= Move;
        _inputHandler.BrakeStartInputReceived -= EnableBrake;
        _inputHandler.BrakeEndInputReceived -= DisableBrake;
    }

    private void Move(float input)
    {
        Debug.Log(input);
        foreach (WheelJoint2D wheelJoint in wheels)
        {
            wheelJoint.connectedBody.AddTorque(- input * wheelSpeed * Time.deltaTime);
            Debug.Log("Moving");
        }
    }

    private void EnableBrake()
    {
        foreach (WheelJoint2D wheelJoint in wheels)
        {
            wheelJoint.useMotor = true;
        }
    }

    private void DisableBrake()
    {
        foreach (WheelJoint2D wheelJoint in wheels)
        {
            wheelJoint.useMotor = false;
        }
    }
}
