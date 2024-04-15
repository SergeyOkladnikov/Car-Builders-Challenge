using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPart : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth;
    private int _health;
    // Start is called before the first frame update

    private void Start()
    {
        _health = _maxHealth;
    }
    public void TakeDamage(int damage)
    {
        _health -= damage;
        //DEBUG
        foreach(SpriteRenderer child in GetComponentsInChildren<SpriteRenderer>())
        {
            Color tmp = child.color;
            tmp.a = (float)_health / _maxHealth;
            child.color = tmp;
        }
        

        if (_health < 0 )
        {
            Destroy(this.gameObject);
        }
    }
}
