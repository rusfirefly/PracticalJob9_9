
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
            Boooom();
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
}
