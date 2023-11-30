using Dreamteck.Splines;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public event Action OnLevelFinish;
    public event Action OnLevelFail;

    [SerializeField] private float _speed;
    [SerializeField] private float _speedIncreaseMultiplier;
    [Space]
    [SerializeField] private PathGenerator _path;

    public PathGenerator path => _path;
    public float speed => _speed;
    public float speedIncreaseMultiplier => _speedIncreaseMultiplier;

    public void Init()
    { 
    
    }

    public void LevelStart()
    {
        
    }

    public void LevelRestart()
    { 
    
    } 
}
