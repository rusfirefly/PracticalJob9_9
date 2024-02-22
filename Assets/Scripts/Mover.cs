using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField, Range(0,20)] private float _speed;
    private bool _isRun;

    private Vector3 _direction;

    private void Awake()
    {
        _direction = Vector3.forward;
    }

    private void Update()
    {
        if (_isRun == false)
            return;

        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    public void Enable() => _isRun = true;
    public void Disable() => _isRun = false;

}
