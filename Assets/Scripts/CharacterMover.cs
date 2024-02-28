using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMover : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private float velocity;
    [SerializeField] private bool blockRotationPlayer;

    private float _inputX;
    private float _inputZ;
    private Vector3 _desiredMoveDirection;
    private float _desiredRotationSpeed = 0.1f;
    private float _speed;
    private float _allowPlayerRotation = 0.1f;
    private CharacterController _controller;
    private bool _isGrounded;
    private Camera _camera;
    private float _verticalVelocity;
    private Vector3 moveVector;
    private bool _isMove;

    private void Start()
    {
        _camera = Camera.main;
        _controller = this.GetComponent<CharacterController>();
        _character = GetComponent<Character>();
        _isMove = true;
    }

    private void Update()
    {
        if (_isMove == false) return;
        InputMagnitude();

        _isGrounded = _controller.isGrounded;
        if (_isGrounded)
        {
            _verticalVelocity -= 0;
        }
        else
        {
            _verticalVelocity -= 1;
        }
        moveVector = new Vector3(0, _verticalVelocity * .2f * Time.deltaTime, 0);

        _controller.Move(moveVector);
    }

    public void StopMove()
    {
        _isMove = false;
    }

    public void StartMove()
    {
        _isMove = true;
    }

    private void PlayerMoveAndRotation()
    {
        _inputX = Input.GetAxis("Horizontal");
        _inputZ = Input.GetAxis("Vertical");

        var camera = Camera.main;
        var forward = _camera.transform.forward;
        var right = _camera.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        _desiredMoveDirection = forward * _inputZ + right * _inputX;

        if (blockRotationPlayer == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_desiredMoveDirection), _desiredRotationSpeed);
            _controller.Move(_desiredMoveDirection * Time.deltaTime * velocity);
        }
    }

    private void LookAt(Vector3 pos)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(pos), _desiredRotationSpeed);
    }

    private void InputMagnitude()
    {
        _inputX = Input.GetAxis("Horizontal");
        _inputZ = Input.GetAxis("Vertical");

        _speed = new Vector2(_inputX, _inputZ).sqrMagnitude;

        if (_speed > _allowPlayerRotation)
        {
            _character.Blend(_speed);
            PlayerMoveAndRotation();
        }
        else if (_speed < _allowPlayerRotation)
        {
            _character.Blend(_speed);
        }
    }

}
