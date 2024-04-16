using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject _resourcesCanvas;
    [SerializeField]
    private GameObject _startCanvas;
    [SerializeField]
    private GameObject _mapCanvas;
    [SerializeField]
    private GameObject _workshopCanvas;
    [SerializeField]
    private GameObject _fightCanvas;
    [SerializeField]
    private GameObject _winCanvas;
    [SerializeField]
    private GameObject _loseCanvas;
    [SerializeField]
    private FightController _fightController;
    // Start is called before the first frame update
    private void Start()
    {
        if (!_fightController)
        {
            _fightController = FindObjectOfType<FightController>();
        }
        _fightController.OnWin += ToWin;
        _fightController.OnLose += ToLose;

    }

    public void ToStart()
    {
        _resourcesCanvas.SetActive(true);
        _startCanvas.SetActive(true);
    }

    public void ToWorkshop()
    {
        _resourcesCanvas.SetActive(true);
        _workshopCanvas.SetActive(true);
    }
    public void ToMap()
    {
        _resourcesCanvas.SetActive(true);
        _mapCanvas.SetActive(true);
    }
    public void ToFight()
    {
        _resourcesCanvas.SetActive(false);
        _fightCanvas.SetActive(true);
    }
    public void ToWin()
    {
        _fightCanvas.SetActive(false);
        _resourcesCanvas.SetActive(true);
        _winCanvas.SetActive(true);
    }
    public void ToLose()
    {
        _fightCanvas.SetActive(false);
        _resourcesCanvas.SetActive(true);
        _loseCanvas.SetActive(true);
    }
}
