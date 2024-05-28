using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProgress : MonoBehaviour
{
    public PlayerInfo playerInfo;
    [SerializeField]
    private TMP_Text _nameText;
    [SerializeField]
    private TMP_Text _levelText;
    [SerializeField]
    private TMP_Text _chipText;
    [SerializeField]
    private TMP_Text _moneyText;
    [SerializeField]
    private TMP_Text _boostText;
    [SerializeField]
    private Image _progressBar;

    private void UpdateNameText()
    {
        _nameText.text = playerInfo.name;
    }

    private void UpdateResourcesText()
    {
        _chipText.text = playerInfo.chips.ToString();
        _moneyText.text = playerInfo.money.ToString();
        _boostText.text = $"{playerInfo.boosts}/{playerInfo.maxBoosts}";
    }

    private void UpdateLevelUI()
    {
        _levelText.text = playerInfo.level.ToString();
        _progressBar.fillAmount = playerInfo.levelProgess;
    }

    private void Start()
    {
        Test();
    }

    private void Test()
    {
        UpdateNameText();
        UpdateResourcesText();
        UpdateLevelUI();
    }
}
