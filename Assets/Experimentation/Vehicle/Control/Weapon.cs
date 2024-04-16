using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private int _damage;
    [SerializeField]
    private float _cooldown;
    [SerializeField]
    private bool _isReady = true;
    private WeaponRay _raycaster;
    // Start is called before the first frame update
    private void Start()
    {
        _raycaster = GetComponentInChildren<WeaponRay>();
    }

    public bool IsReady()
    {
        return _isReady;
    }


    public void Shoot()
    {
        if (_isReady)
        {
            _raycaster.Shoot(_damage);
            StartCoroutine(CoolDown());
        }
    }


    private IEnumerator CoolDown()
    {
        _isReady = false;
        yield return new WaitForSeconds(_cooldown);
        _isReady = true;
        //Debug.Log("Weapon Ready");
    }
}
