using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField, Range(0, 20)] private float _speed;

    private Point _point;
    private bool _isRun;

    private Vector3 _direction;

    private void Awake()
    {
        _direction = Vector3.forward;
        _point = new Point(minPositionX: -10, maxPositionZ: 10);
        transform.LookAt(_point.GetPoint);
    }


    private void Update()
    {
        if (_isRun == false)
            return;

        transform.LookAt(_point.GetPoint);

        if (_point.CheckDistance(transform.position))
        {
            _point.NewPoint();
            transform.LookAt(_point.GetPoint);
        }

        transform.Translate(_direction * _speed * Time.deltaTime);
    }
    
    public void Enable() => _isRun = true;

    public void Disable() => _isRun = false;

    
}
