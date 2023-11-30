using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Menu
{
    public event Action OnLevelStart;

    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private Button _playButton;

    private void OnEnable() => _playButton.onClick.AddListener(() => OnLevelStart?.Invoke());

    private void OnDisable() => _playButton.onClick.RemoveListener(() => OnLevelStart?.Invoke());

    protected override void OnInit() => _levelText.text = $"Level #{level}";
}