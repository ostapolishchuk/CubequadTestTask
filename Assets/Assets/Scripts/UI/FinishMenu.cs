using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinishMenu : Menu
{
    public event Action OnLevelNext;

    [SerializeField] private Button _nextButton;

    private void OnEnable() => _nextButton.onClick.AddListener(() => OnLevelNext?.Invoke());

    private void OnDisable() => _nextButton.onClick.RemoveListener(() => OnLevelNext?.Invoke());
}
