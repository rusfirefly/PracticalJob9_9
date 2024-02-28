using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _force = 30f;
    [SerializeField] private float _attackRange;
    [SerializeField] private Transform _pointAttack;
    [SerializeField] private LayerMask _targetMask;
    private bool _isAttack;

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
            Attack();
            _isAttack = false;
        }
    }

    private void OnAttackEvent()
    {
        _isAttack = true;
    }

    private void Attack()
    {
        Collider[] hitEnemys = Physics.OverlapSphere(_pointAttack.position, _attackRange, _targetMask);
        foreach(Collider enemy in hitEnemys)
        {
            Vector3 hitPoint = enemy.ClosestPoint(transform.position);
            Enemy hitEnemy = enemy.GetComponentInParent<Enemy>();
            if (hitEnemy != null)
            {
                Vector3 forceDirection = (hitPoint - _pointAttack.position).normalized;
                hitEnemy.TakeDamage(forceDirection * _force, hitPoint);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_pointAttack.position, _attackRange);
    }
}
