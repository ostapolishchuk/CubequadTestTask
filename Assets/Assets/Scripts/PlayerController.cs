using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speedMultiplier;
    [SerializeField] private float _limit;
    [SerializeField] private SplinePositioner positioner;

    private bool _moving;
    private float _distance;
    private float _finishDistance;
    private float _speed;
    private float _speedIncreaseMultiplier;
    private float _offsetLimit;

    private void Update()
    {
        if (!_moving)
            return;

        _distance += Time.deltaTime * _speed;
        positioner.SetDistance(_distance);

        _speed *= _speedIncreaseMultiplier;

        if (_distance >= _finishDistance)
            LevelFinish();
    }

    public void Init(PathGenerator path, float speed, float speedIncreaseMultiplier)
    {
        positioner.spline = path.spline;

        _distance = 0;
        _finishDistance = path.spline.CalculateLength(0, 1);

        positioner.SetDistance(_distance);

        _speed = speed * _speedMultiplier;
        _speedIncreaseMultiplier = speedIncreaseMultiplier;

        _offsetLimit = path.size / 2f;
    }

    public void LevelStart()
    {
        InputEvents.OnDrag += Drag;
        _moving = true;
    }

    private void LevelFinish()
    {
        InputEvents.OnDrag -= Drag;
        _moving = false;
    }

    private void LevelFail()
    {
        InputEvents.OnDrag -= Drag;
        _moving = false;
    }

    private void Drag(Vector2 drag)
    {
        Debug.Log(drag.x);
    }
}
