using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGravity : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float horizontalInput;
    private float verticalInput;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        transform.Translate(moveDirection * _speed * Time.deltaTime);
    }
}
