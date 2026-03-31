using UnityEngine;

[RequireComponent(typeof(Mover))]
public class GoPlaces : MonoBehaviour
{
    [SerializeField] private Transform _allPlaces;

    private Mover _mover;
    private int _placeIndex = 0;
    private Transform[] _places;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }
    private void OnEnable()
    {
        _mover.PointReached += GetNextPlace;
    }

    private void Start()
    {
        if (_allPlaces == null || _allPlaces.childCount == 0)
            return;

        _places = new Transform[_allPlaces.childCount];

        for (int i = 0; i < _allPlaces.childCount; i++)
            _places[i] = _allPlaces.GetChild(i);

        SendToCurrentPlace();
    }

    private void OnDisable()
    {
        _mover.PointReached -= GetNextPlace;
    }

    private void GetNextPlace()
    {
        _placeIndex = (_placeIndex + 1) % _places.Length;
        SendToCurrentPlace();
    }

    private void SendToCurrentPlace()
    {
        if (_places.Length > 0)
            _mover.SetTarget(_places[_placeIndex].position);
    }
}