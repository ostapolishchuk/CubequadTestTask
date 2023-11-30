using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public event Action OnLevelStart;
    public event Action OnLevelNext;
    public event Action OnLevelRestart;

    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private GameplayMenu _gameplayMenu;
    [SerializeField] private FinishMenu _finishMenu;
    [SerializeField] private FailMenu _failMenu;

    private void OnEnable()
    {
        _mainMenu.OnLevelStart += LevelStart;
        _gameplayMenu.OnLevelRestart += LevelRestart;
        _finishMenu.OnLevelNext += LevelNext;
        _failMenu.OnLevelRestart += LevelRestart;
    }

    private void OnDisable()
    {
        _mainMenu.OnLevelStart -= LevelStart;
        _gameplayMenu.OnLevelRestart -= LevelRestart;
        _finishMenu.OnLevelNext -= LevelNext;
        _failMenu.OnLevelRestart -= LevelRestart;
    }

    public void Init(int level)
    {
        _mainMenu.Init(level);
        _gameplayMenu.Init(level);
        _finishMenu.Init(level);
        _failMenu.Init(level);

        HideAll();
        _mainMenu.Show();
    }

    public void LevelFinish() => Show(_finishMenu);

    public void LevelFail() => Show(_failMenu);

    private void LevelStart()
    {
        OnLevelStart?.Invoke();
        Show(_gameplayMenu);
    }

    private void LevelNext()
    {
        OnLevelNext?.Invoke();
        Show(_mainMenu);
    }

    private void LevelRestart()
    {
        OnLevelRestart?.Invoke();
        Show(_mainMenu);
    }

    private void Show(Menu menu)
    {
        HideAll();
        menu.Show();
    }

    private void HideAll()
    {
        _mainMenu.Hide();
        _gameplayMenu.Hide();
        _finishMenu.Hide();
        _failMenu.Hide();
    }
}