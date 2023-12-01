using Dreamteck.Splines;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _speedIncreaseMultiplier = 1.001f;
    [Space]
    [SerializeField] private PathGenerator _path;

    public PathGenerator path => _path;
    public float speed => _speed;
    public float speedIncreaseMultiplier => _speedIncreaseMultiplier;

    public void Init()
    { 
    
    }
}