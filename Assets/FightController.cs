using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightController : MonoBehaviour
{
    [SerializeField]
    private GameObject _testPlayerPrefab;
    [SerializeField]
    private GameObject _testEnemyPrefab;
    [SerializeField]
    private GameObject _testLevelPrefab;
    private GameObject _playerVehicle;
    private GameObject _enemyVehicle;
    private GameObject _level;
    private CarPart _playerDriver;
    private CarPart _enemyDriver;

    public event Action OnWin;
    public event Action OnLose;
    public event Action OnStart;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void TestStubStartFight()
    {
        //Debug.Log("Fight");
        _level = Instantiate(_testLevelPrefab);
        _playerVehicle = Instantiate(_testPlayerPrefab, new Vector3(-30, 3, 0), new Quaternion());
        _enemyVehicle = Instantiate(_testEnemyPrefab, new Vector3(30, 3, 0), new Quaternion());
        _playerDriver = _playerVehicle.GetComponentInChildren<Driver>().GetComponent<CarPart>();
        _enemyDriver = _enemyVehicle.GetComponentInChildren<Driver>().GetComponent<CarPart>();
        _playerDriver.OnDestruction += Lose;
        _enemyDriver.OnDestruction += Win;
        OnStart?.Invoke();
        Debug.Log("Start");
    }

    public void TestStubClearFight()
    {
        _playerDriver.OnDestruction -= Lose;
        _enemyDriver.OnDestruction -= Win;
        Destroy(_playerVehicle);
        Destroy(_enemyVehicle);
        Destroy(_level);
        Debug.Log("Clear");
    }

    public void TestStubRestart()
    {
        TestStubClearFight();
        TestStubStartFight();
    }

    private void Win()
    {
        OnWin?.Invoke();
    }

    private void Lose()
    {
        OnLose?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
