using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _distance = 7f;
    [SerializeField] private float _height = 3f;
    [SerializeField] private float _speed = 3;


    private void FixedUpdate()
    {

    }

}
