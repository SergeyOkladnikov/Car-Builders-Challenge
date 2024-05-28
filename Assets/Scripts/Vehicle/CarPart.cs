using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPart : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth = 100;
    [SerializeField]
    private bool _isDestructable;
    private float _health;


    public event Action OnDestruction;
    public event Action<float> OnDamage;
    // Start is called before the first frame update

    public float getHealth()
    {
        return _health;
    }

    private void Start()
    {
        _health = _maxHealth;
    }
    public void TakeDamage(float damage)
    {
        _health -= damage;
        OnDamage?.Invoke(damage);
        //DEBUG
        foreach (SpriteRenderer child in GetComponentsInChildren<SpriteRenderer>())
        {
            Color tmp = child.color;
            tmp.a = _health / _maxHealth;
            child.color = tmp;
        }
        

        if (_health <= 0 && _isDestructable)
        {
            OnDestruction?.Invoke();
            Destroy(gameObject);
        }
    }
}
