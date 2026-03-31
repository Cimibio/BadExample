using System.Collections;
using UnityEngine;

public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private float _timeWaitShooting = 1f;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _target;

    private void Start()
    {
        if (_target != null)
            StartCoroutine(ShootRoutine());
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

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}
