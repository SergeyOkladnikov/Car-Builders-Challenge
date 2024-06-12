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
    private float _range;
    public WeaponRay raycaster;
    // Start is called before the first frame update
    private void Start()
    {
        raycaster = GetComponentInChildren<WeaponRay>();
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

        return raycaster?.CastRay(_range);
    }

    private IEnumerator CoolDown()
    {
        _isReady = false;
        yield return new WaitForSeconds(_cooldown);
        _isReady = true;
        //Debug.Log("Weapon Ready");
    }
}
