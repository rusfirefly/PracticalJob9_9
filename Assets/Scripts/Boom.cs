
using UnityEngine;

public class Boom : MonoBehaviour
{
    [SerializeField] private float _power;
    [SerializeField] private float _radius;
    private float _curentTime;
    private float _coldownTime = 3f;

    private void FixedUpdate()
    {
        _curentTime += Time.deltaTime;
        Debug.Log($"{_coldownTime - _curentTime}");
        if(_curentTime >= _coldownTime)
        {
            Boooom2();
            _curentTime -= _coldownTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

    private void Boooom()
    {
        Rigidbody[] boxs = FindObjectsOfType<Rigidbody>();
        foreach(Rigidbody box in boxs)
        {
            float distance = Vector3.Distance(transform.position, box.transform.position);
            if(distance <= _radius)
            {
                Vector3 direction = box.transform.position - transform.position;
                box.AddForce(direction.normalized *_power *(_radius - distance), ForceMode.Impulse);
            }
        }
    }
    private void Boooom2()
    {
        Rigidbody[] enemys = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody enemy in enemys)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance <= _radius)
            {
                Vector3 direction = Vector3.up + (enemy.transform.position - transform.position);
                enemy.AddForce(direction * _power * (_radius - distance), ForceMode.Impulse);
            }
        }
    }
}
