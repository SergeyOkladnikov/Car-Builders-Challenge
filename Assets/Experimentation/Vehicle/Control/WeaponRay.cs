using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRay : MonoBehaviour
{
    [SerializeField]
    private int _range;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update() 
    {
        //DEBUG
        Ray2D _ray = new Ray2D(transform.position, transform.right);
        Debug.DrawRay(_ray.origin, _ray.direction * _range, Color.yellow);
    }

    public GameObject CastRay()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, _range);
        if (hit)
        {
            return hit.transform.gameObject;
        }
        return null;
    }

    public void Shoot(int damage)
    {
        var _target = CastRay();
        //Debug.Log(_target);
        if (_target)
        {
            var _carPart = _target.GetComponent<CarPart>();
            if (_carPart)
            {
                _carPart.TakeDamage(damage);
            }
        }
    }
}
