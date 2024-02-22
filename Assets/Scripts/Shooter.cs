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
                Enemy enemy = hit.collider.GetComponentInParent<Enemy>();
                if(enemy!=null)
                {
                    Vector3 forceDirection = (hit.transform.position - _camera.transform.position).normalized;
                    enemy.TakeDamage(forceDirection * _force, hit.transform.position);
                }
            }
        }
    }

}
