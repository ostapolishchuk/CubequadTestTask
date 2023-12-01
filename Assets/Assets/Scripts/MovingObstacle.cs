using DG.Tweening;
using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private float _offsetLimit;
    [SerializeField] private float _time;
    [SerializeField] private Ease _ease;
    [SerializeField] private SplinePositioner _positioner;

    private void Start()
    {
        _positioner.motion.offset = new Vector2(-_offsetLimit, 0);
        Move();
    }

    private void Move()
    {
        DOTween.To(() => _positioner.motion.offset.x, x => _positioner.motion.offset = new Vector2(x, 0), _offsetLimit, _time)
               .SetEase(_ease).SetAutoKill(true).OnComplete(MoveReversed);
    }

    private void MoveReversed()
    {
        DOTween.To(() => _positioner.motion.offset.x, x => _positioner.motion.offset = new Vector2(x, 0), -_offsetLimit, _time)
               .SetEase(_ease).SetAutoKill(true).OnComplete(Move);
    }
}
