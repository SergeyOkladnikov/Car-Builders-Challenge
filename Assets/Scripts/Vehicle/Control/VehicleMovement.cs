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
    private int _wheelSpeed;
    [SerializeField]
    private IFightInput _inputHandler;
    private WheelJoint2D[] _wheels;
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
        
        _wheels = GetComponentsInChildren<WheelJoint2D>();
        _inputHandler.MovementInputReceived += Move;
        _inputHandler.BrakeStartInputReceived += EnableBrake;
        _inputHandler.BrakeEndInputReceived += DisableBrake;
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
        foreach (WheelJoint2D wheelJoint in _wheels)
        {
            wheelJoint.connectedBody.AddTorque(- input * _wheelSpeed * Time.deltaTime);
        }
    }

    private void EnableBrake()
    {
        foreach (WheelJoint2D wheelJoint in _wheels)
        {
            wheelJoint.useMotor = true;
        }
    }

    private void DisableBrake()
    {
        foreach (WheelJoint2D wheelJoint in _wheels)
        {
            wheelJoint.useMotor = false;
        }
    }
}
