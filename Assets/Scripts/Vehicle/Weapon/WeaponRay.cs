using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRay : MonoBehaviour
{
    [SerializeField]
    private float _range;
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

    public GameObject CastRay(float range)
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, range);
        if (hit)
        {
            return hit.collider.gameObject;
        }
        return null;
    }
}
