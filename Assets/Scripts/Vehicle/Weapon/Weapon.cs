using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float _damage;
    [SerializeField]
    private float _cooldown;
    [SerializeField]
    private bool _isReady = true;
    [SerializeField]
    private int _range;
    /*private WeaponRay _raycaster;
    // Start is called before the first frame update
    private void Start()
    {
        _raycaster = GetComponentInChildren<WeaponRay>();
    }*/

    void Update()
    {
        Ray2D _ray = new Ray2D(transform.position, transform.right);
        Debug.DrawRay(_ray.origin, _ray.direction * _range, Color.yellow);
    }

    public bool IsReady()
    {
        return _isReady;
    }


    public void Shoot()
    {
        if (_isReady)
        {
            var _target = CastRay();
            Debug.Log(_target);
            if (_target)
            {
                var _carPart = _target.GetComponent<CarPart>();
                if (_carPart)
                {
                    _carPart.TakeDamage(_damage);
                }
            }
            StartCoroutine(CoolDown());
        }
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


    private IEnumerator CoolDown()
    {
        _isReady = false;
        yield return new WaitForSeconds(_cooldown);
        _isReady = true;
        //Debug.Log("Weapon Ready");
    }
}
