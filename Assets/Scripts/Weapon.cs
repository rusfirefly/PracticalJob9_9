using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool _isAttack;
    private float _force = 30f;

    private void OnEnable()
    {
        Character.AttackEvent += OnAttackEvent;
    }

    private void OnDisable()
    {
        Character.AttackEvent -= OnAttackEvent;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_isAttack)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Enemy enemy = hit.collider.GetComponentInParent<Enemy>();
                if (enemy != null)
                {
                    Debug.DrawRay(transform.forward, Vector3.forward, Color.red, 20f);
                    if (Vector3.Distance(transform.position, hit.transform.position) <= 2f)
                    {
                        Vector3 forceDirection = (hit.transform.position - transform.position).normalized;
                        enemy.TakeDamage(forceDirection * _force, hit.transform.position);
                    }
                }
            }
            

            /*Enemy enemy = other.GetComponentInParent<Enemy>();
            if (enemy != null)
            {
                Vector3 forceDirection = (transform.position).normalized;
                enemy.TakeDamage(forceDirection * _force, transform.position);
            }*/
            _isAttack = false;
        }
    }

    private void OnAttackEvent()
    {
        _isAttack = true;
    }
}
