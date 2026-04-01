using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _timeWaitShooting = 1f;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _target;

    private Coroutine _shootRoutine;
    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new WaitForSeconds(_timeWaitShooting);
    }

    private void OnEnable()
    {
        if (_target != null)
            _shootRoutine = StartCoroutine(ShootRoutine());
    }

    private void OnDisable()
    {
        if (_shootRoutine != null)
        {
            StopCoroutine(_shootRoutine);
            _shootRoutine = null;
        }
    }

    private IEnumerator ShootRoutine()
    {
        while (enabled)
        {
            if (_target != null)
            {
                Vector3 direction = (_target.position - transform.position).normalized;
                Bullet bullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);
                bullet.Init(direction);
            }

            yield return _wait;
        }
    }
}
