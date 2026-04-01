using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 100f;

    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(Vector3 direction)
    {
        transform.up = direction;

        if (_rigidbody != null)
            _rigidbody.velocity = direction.normalized * _speed;
    }
}
