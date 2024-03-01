using UnityEngine;

public class Shooter : MonoBehaviour
{
    private const int _leftMouseButtonClick = 0;
    [SerializeField, Range(0,10000)] private float _force;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(_leftMouseButtonClick))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 forceDirection;
                Enemy enemy = hit.collider.GetComponentInParent<Enemy>();
                if(enemy!=null)
                {
                   forceDirection = (hit.transform.position - _camera.transform.position).normalized;
                   enemy.TakeDamage(forceDirection * _force, hit.transform.position);
                }

                Ball ball = hit.collider.GetComponentInParent<Ball>();
                if (ball)
                {
                    forceDirection = (hit.transform.position - _camera.transform.position).normalized;
                    ball.TakeDamage(forceDirection * _force, hit.transform.position);
                }
            }
        }
    }

}
