using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private float _number;
    [SerializeField] private float _timeWaitShooting;
    [SerializeField] Bullet _prefab;

    private Transform _target;
    private Coroutine _shoot;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWorking = enabled;

        while (isWorking)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Bullet bullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            bullet.GetComponent<Rigidbody>().transform.up = direction;
            bullet.GetComponent<Rigidbody>().velocity = direction * _number;

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}