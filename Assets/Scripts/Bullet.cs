using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Bullet : MonoBehaviour
{
    private Mover _mover;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    public void Init(Vector3 direction)
    {
        _mover.SetDirection(direction);
    }
}
