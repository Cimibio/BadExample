using System;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Rigidbody _rigidbody;
    private Vector3 _movePointPosition;
    private bool _hasTarget;
    private float _minDistance = 0.1f;

    public event Action PointReached;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_hasTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, _movePointPosition, _speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _movePointPosition) < _minDistance)
            {
                _hasTarget = false;
                PointReached?.Invoke();
            }    
        }
    }

    public void SetDirection(Vector3 direction)
    {
        _hasTarget = false;
        transform.up = direction;

        if (_rigidbody != null)
            _rigidbody.velocity = direction.normalized * _speed;
    }

    public void SetMovePoint(Vector3 target)
    {
        _movePointPosition = target;
        _hasTarget = true;
        transform.forward = _movePointPosition - transform.position;
    }
}
