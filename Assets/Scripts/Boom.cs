
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
        Enemy[] enemys = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemys)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance <= _radius)
            {
                Vector3 direction = enemy.transform.position - transform.position;
                enemy.TakeDamage(direction * _power * (_radius - distance), Vector3.up);
            }
        }
    }

}
