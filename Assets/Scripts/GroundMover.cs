using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class GroundMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _locationLength;
    [SerializeField] private float _speed;
    [SerializeField] private List<Transform> _locations;

    private Transform _currentLocation;
    private Transform _nextLocation;
    private Vector3 _endPosition;
    private Vector3 _nextPosition;

    private void Start()
    {
        _endPosition = new Vector3(0, 0, -_locationLength);
        _nextPosition = new Vector3(0, 0, _locationLength);
        _currentLocation = _locations[0];
        _currentLocation.gameObject.SetActive(true);
    }


    private void Update()
    {
        if (_nextLocation == null)
        {
            int randomIndex = Random.Range(0, _locations.Count);
            _nextLocation = _locations[randomIndex];
            if (_currentLocation != _nextLocation)
            {
                _nextLocation.gameObject.SetActive(true);
                _nextLocation.position = _nextPosition;
            }
            else
            {
                _nextLocation = null;
            }
            Debug.Log(_nextLocation + " " + randomIndex);
        }
        else if(_currentLocation.position != _endPosition && _nextLocation != null)
        {
            _currentLocation.position = Vector3.MoveTowards(_currentLocation.position, _endPosition, _speed * Time.deltaTime);
            _nextLocation.position = Vector3.MoveTowards(_nextLocation.position, _startPosition, _speed * Time.deltaTime);
        }
        else
        {
            _currentLocation.gameObject.SetActive(false);
            _currentLocation = _nextLocation;
            _nextLocation = null;
        }
        
    }
}
