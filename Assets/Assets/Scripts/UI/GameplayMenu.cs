using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayMenu : Menu
{
    public event Action OnLevelRestart;

    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private Button _playButton;

    private void OnEnable() => _playButton.onClick.AddListener(() => OnLevelRestart?.Invoke());

    private void OnDisable() => _playButton.onClick.RemoveListener(() => OnLevelRestart?.Invoke());

    protected override void OnInit() => _levelText.text = $"Level #{level}";
}
