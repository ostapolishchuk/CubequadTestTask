using DG.Tweening;
using Dreamteck.Splines;
using System;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    public event Action OnLevelFinish;
    public event Action OnLevelFail;

    [SerializeField] private float _speedMultiplier = 1f;
    [SerializeField] private float _limitBorder = 0.1f;
    [Space]
    [SerializeField] private float _rotatingTime;
    [Space]
    [SerializeField] private Animator _animator; 
    [SerializeField] private Transform _camera;
    [Space]
    [SerializeField] private SplinePositioner _positioner;

    private bool _moving;
    private float _distance;
    private float _finishDistance;
    private float _speed;
    private float _speedIncreaseMultiplier;
    private float _offsetLimit;
    private Vector2 _startOffset;
    private SplineComputer _spline;

    private void Update()
    {
        if (!_moving)
            return;

        _distance += Time.deltaTime * _speed;
        _positioner.SetDistance(_distance);

        _speed *= _speedIncreaseMultiplier;

        if (_distance >= _finishDistance)
            LevelFinish();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
            LevelFail();
    }

    private void OnDestroy()
    {
        InputEvents.OnDrag -= Drag;
        InputEvents.OnTap -= Tap;
    }

    [Inject]
    public void Inject(LevelController level)
    {
        _positioner.spline = level.path.spline;

        _distance = 0;
        _finishDistance = level.path.spline.CalculateLength(0, 1);

        _positioner.SetDistance(_distance);

        _speed = level.speed * _speedMultiplier;
        _speedIncreaseMultiplier = level.speedIncreaseMultiplier;

        _offsetLimit = (level.path.size / 2f) - _limitBorder;

        InputEvents.OnDrag += Drag;
        InputEvents.OnTap += Tap;
    }

    public void LevelStart()
    {
        _moving = true;
        _animator.SetTrigger("Run");
    }

    private void LevelFinish()
    {
        _moving = false;
        _animator.transform.DOLocalRotate(new Vector3(0, 180, 0), _rotatingTime).SetAutoKill(true);
        _animator.SetTrigger("Dance");

        OnLevelFinish?.Invoke();
    }

    private void LevelFail()
    {
        _moving = false;
        _animator.SetTrigger("Idle");

        OnLevelFail?.Invoke();
    }

    private void Tap(bool value)
    {
        if (value)
            _startOffset = _positioner.motion.offset;
    }

    private void Drag(Vector2 drag)
    {
        if (!_moving)
            return;

        _positioner.motion.offset = _startOffset + new Vector2(drag.x / 25f, 0);

        if (_positioner.motion.offset.x >= _offsetLimit)
            _positioner.motion.offset = new Vector2(_offsetLimit, 0);
        else if (_positioner.motion.offset.x <= -_offsetLimit)
            _positioner.motion.offset = new Vector2(-_offsetLimit, 0);

        _camera.localPosition = new Vector3(-_positioner.motion.offset.x, _camera.localPosition.y, _camera.localPosition.z);
    }
}
