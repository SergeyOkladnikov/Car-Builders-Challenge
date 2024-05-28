using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleState : MonoBehaviour
{
    [SerializeField]
    private float _totalHealth = 0;
    private CarPart[] _parts;
    public event Action Death;
    // Start is called before the first frame update

    private void OnEnable()
    {
        _parts = GetComponentsInChildren<CarPart>();
        foreach (CarPart part in _parts)
        {
            _totalHealth += part.getHealth() / 2;
            part.OnDamage += TakeDamageTotal;
            part.OnDestruction += ResetParts;
        }
    }


    private void TakeDamageTotal(float damage)
    {
        _totalHealth -= damage;
        if (_totalHealth < 0)
        {
            Death?.Invoke();
        }
    }

    private void ResetParts()
    {
        throw new NotImplementedException();
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
