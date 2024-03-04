using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody _ballRiginboddy;
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
       
}
