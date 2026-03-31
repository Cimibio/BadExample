using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _arrivalThreshold = 0.01f;

    private Vector3 _targetPosition;
    private bool _hasTarget = false;

    public event Action PointReached;

    private void Update()
    {
        if (_hasTarget == false)
            return;

        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _targetPosition) < _arrivalThreshold)
        {
            _hasTarget = false;
            PointReached?.Invoke();
        }
    }

    public void SetMovePoint(Vector3 target)
    {
        _targetPosition = target;
        transform.forward = target - transform.position;
        _hasTarget = true;
    }
}