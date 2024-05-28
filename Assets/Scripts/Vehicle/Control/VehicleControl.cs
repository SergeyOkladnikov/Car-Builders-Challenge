using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private CarPart _driver;
    private VehicleMovement _vehicleMovement;
    private VehicleAttack _vehicleAttack;

    private void OnEnable()
    {
        _driver = GetComponentInChildren<Driver>().GetComponent<CarPart>();
        _vehicleMovement = GetComponent<VehicleMovement>();
        _vehicleAttack = GetComponent<VehicleAttack>();
        _driver.OnDestruction += DisableControl;
    }

    private void DisableControl()
    {
        _vehicleMovement.enabled = false;
        _vehicleAttack.enabled = false;
    }
}
