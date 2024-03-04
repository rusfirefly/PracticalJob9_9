using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _distance = 7f;
    [SerializeField] private float _height = 3f;
    [SerializeField] private float _speed = 3;
    private Vector3 _targetPosition;

    private void FixedUpdate()
    {
        _targetPosition = _target.position - _target.forward * _distance + Vector3.up * _height;
        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * 3f);
        transform.LookAt(_target);
    }

}
