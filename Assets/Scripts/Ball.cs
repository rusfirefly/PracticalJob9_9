using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody _ballRiginboddy;
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private float _attackRange;

    private void OnValidate()
    {
        _ballRiginboddy ??= GetComponent<Rigidbody>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }

    public void TakeDamage(Vector3 force, Vector3 hitPosition)
    {
        _ballRiginboddy.AddForceAtPosition(force, hitPosition, ForceMode.Impulse);
    }

    private void Attack()
    {
        Collider[] hitEnemys = Physics.OverlapSphere(transform.position, _attackRange, _targetMask);
        foreach (Collider enemy in hitEnemys)
        {
            Vector3 hitPoint = enemy.ClosestPoint(transform.position);
            Enemy hitEnemy = enemy.GetComponentInParent<Enemy>();
            if (hitEnemy != null)
            {
                Vector3 forceDirection = (hitPoint - transform.position).normalized;
                hitEnemy.TakeDamage(forceDirection * 100f, hitPoint);
            }
        }
    }
}
