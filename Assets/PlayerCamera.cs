using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Player _player;
    [SerializeField]
    private FightController _fightController;
    // Start is called before the first frame update
    void Start()
    {
        _fightController.OnStart += FindPlayer;
    }

    private void FindPlayer()
    {
        _player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player)
        {
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);
        }
    }
}
