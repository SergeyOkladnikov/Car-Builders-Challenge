using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lvlButton : MonoBehaviour
{
    [SerializeField]
    private int _levelId;
    [SerializeField]
    private Image _cross;
    [SerializeField]
    private Image _check;

    [SerializeField]
    private Button _button;

    public void Enable()
    {
        _button.interactable = true;
    }
    public void Disable()
    {
        _button.interactable = false;
        _cross.gameObject.SetActive(true);
    }
    public void Check()
    {
        _check.gameObject.SetActive(true);
    }
}
