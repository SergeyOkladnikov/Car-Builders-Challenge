using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleAttack : MonoBehaviour
{
    [SerializeField]
    private bool isBotControlled;
    [SerializeField]
    private IFightInput _inputHandler;
    // Start is called before the first frame update
    private Weapon[] _longRangeWeapons;
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

        _inputHandler.AttackInputReceived += Attack;
        _longRangeWeapons = GetComponentsInChildren<Weapon>();
    }

    private void Attack()
    {
        Debug.Log("Attack");
        foreach (var gun in _longRangeWeapons)
        {
            gun?.Shoot();
        }
    }

    private void OnDisable()
    {
        _inputHandler.AttackInputReceived -= Attack;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
