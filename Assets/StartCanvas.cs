using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartCanvas : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _currentLocText;

    [SerializeField]
    private PlayerProgress _progress;

    private void UpdateText()
    {
        _currentLocText.text = $"Уровень {_progress.playerInfo.currentLoc.ToString()}";
    }

    private void OnEnable()
    {
        Debug.Log("f");
        UpdateText();
    }
}
