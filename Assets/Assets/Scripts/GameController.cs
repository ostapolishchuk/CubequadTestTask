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
    private LevelController _level;

    [Inject]
    public void Inject(CanvasController canvas, PlayerController player, LevelController level)
    {
        _canvas = canvas;
        _player = player;
        _level = level;

        _currentLevel = SceneManager.GetActiveScene().buildIndex;
        _totalLevels = SceneManager.sceneCountInBuildSettings;

        _canvas.Init(_currentLevel + 1);
        _player.Init(level.path, level.speed, level.speedIncreaseMultiplier);
        _level.Init();
    }

    private void OnEnable()
    {
        _canvas.OnLevelStart += _player.LevelStart;
        _canvas.OnLevelNext += LevelNext;
        _canvas.OnLevelRestart += LevelRestart;

        _level.OnLevelFinish += _canvas.LevelFinish;
        _level.OnLevelFail += _canvas.LevelFail;
    }

    private void OnDisable()
    {
        _canvas.OnLevelStart -= _player.LevelStart;
        _canvas.OnLevelNext -= LevelNext;
        _canvas.OnLevelRestart -= LevelRestart;

        _level.OnLevelFinish -= _canvas.LevelFinish;
        _level.OnLevelFail -= _canvas.LevelFail;
    }

    private void LevelRestart() =>  LevelLoad(_currentLevel);

    private void LevelNext() =>  LevelLoad(_currentLevel + 1);

    private void LevelLoad(int index)
    {
        if (index > _totalLevels)
            index -= _totalLevels;

        SceneManager.LoadScene(index);
    }
}