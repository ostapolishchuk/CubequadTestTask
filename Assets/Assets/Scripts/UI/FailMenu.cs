using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FailMenu : Menu
{
    public event Action OnLevelRestart;

    [SerializeField] private Button _restartButton;

    private void OnEnable() => _restartButton.onClick.AddListener(() => OnLevelRestart?.Invoke());

    private void OnDisable() => _restartButton.onClick.RemoveListener(() => OnLevelRestart?.Invoke());
}
