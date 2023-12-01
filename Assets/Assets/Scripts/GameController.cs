using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameController : MonoBehaviour
{
    private int _currentLevel;
    private int _totalLevels;
    private CanvasController _canvas;
    private PlayerController _player;

    [Inject]
    public void Inject(CanvasController canvas, PlayerController player)
    {
        _canvas = canvas;
        _player = player;
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;

        _currentLevel = SceneManager.GetActiveScene().buildIndex;
        _totalLevels = SceneManager.sceneCountInBuildSettings;

        _canvas.Init(_currentLevel + 1);
    }

    private void OnEnable()
    {
        _canvas.OnLevelStart += _player.LevelStart;
        _canvas.OnLevelNext += LevelNext;
        _canvas.OnLevelRestart += LevelRestart;

        _player.OnLevelFinish += _canvas.LevelFinish;
        _player.OnLevelFail += _canvas.LevelFail;
    }

    private void OnDisable()
    {
        _canvas.OnLevelStart -= _player.LevelStart;
        _canvas.OnLevelNext -= LevelNext;
        _canvas.OnLevelRestart -= LevelRestart;

        _player.OnLevelFinish -= _canvas.LevelFinish;
        _player.OnLevelFail -= _canvas.LevelFail;
    }

    private void LevelRestart() =>  LevelLoad(_currentLevel);

    private void LevelNext() =>  LevelLoad(_currentLevel + 1);

    private void LevelLoad(int index)
    {
        if (index > _totalLevels - 1)
            index -= _totalLevels;

        SceneManager.LoadScene(index);
    }
}