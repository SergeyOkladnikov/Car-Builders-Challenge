using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bot : MonoBehaviour, IFightInput
{
    public event Action<float> MovementInputReceived;
    public event Action BrakeStartInputReceived;
    public event Action BrakeEndInputReceived;
    public event Action AttackInputReceived;
    private Weapon[] _weapons;
    private Player _player;
    [SerializeField]
    private float _shotCooldown;
    private float _shotCooldownRemaining;

    // Start is called before the first frame update
    void OnEnable()
    {
        _weapons = GetComponentsInChildren<Weapon>();
        _player = FindObjectOfType<Player>();
        //Debug.Log(_player);
    }

    // Update is called once per frame
    void Update()
    {
        if (_player)
        {
            if (IsAimedAtEnemy())
            {
                //Debug.Log("Bot Aiming");
                if (_shotCooldownRemaining < 0)
                {
                    AttackInputReceived?.Invoke();
                    //print("BotShooting");
                    _shotCooldownRemaining = _shotCooldown;
                }
                else
                {
                    _shotCooldownRemaining -= Time.deltaTime;
                    //Debug.Log(_shotCooldownRemaining);
                }
                BrakeStartInputReceived?.Invoke();
            }
            else
            {
                BrakeEndInputReceived?.Invoke();
                MovementInputReceived?.Invoke(Math.Sign(_player.transform.position.x - transform.position.x));
            }
        }
    }


    private bool IsAimedAtEnemy()
    {
        foreach (Weapon weapon in _weapons)
        {
            if (weapon)
            {
                //Ray2D _ray = new Ray2D(weapon.transform.position, weapon.transform.right);
                //Debug.DrawRay(_ray.origin, _ray.direction * 50, Color.yellow);
                GameObject target = weapon.CastRay();
                if (target) {
                    if (target.GetComponent<CarPart>() && target.gameObject != gameObject)
                    {
                        return true;
                    } 
                }
            }
        }
        return false;
    }
}
