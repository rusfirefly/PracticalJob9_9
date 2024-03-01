using UnityEngine;

public class Gravity : MonoBehaviour
{
    private Rigidbody[] _objects;
    [SerializeField] private LayerMask _objectMask;
    [SerializeField] private float _radiusGravity;

    private void OnTriggerEnter(Collider other)
    {
        Collider[] hitEnemys = Physics.OverlapSphere(transform.position, _radiusGravity, _objectMask);
        foreach (Collider enemy in hitEnemys)
        {
            Enemy hitEnemy = enemy.GetComponentInParent<Enemy>();
            if (hitEnemy != null)
            {
                hitEnemy.Kill();
            }
            else
            {
                OffGravity(other.GetComponents<Rigidbody>());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        OnGravity(other.GetComponents<Rigidbody>());
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _radiusGravity);
    }

    private Rigidbody[] GetObjects() => FindObjectsOfType<Rigidbody>();

    private void OnGravity(Rigidbody[] objects)
    {
        foreach (Rigidbody obj in objects)
            obj.useGravity = true;
    }
    
    private void OffGravity(Rigidbody[] objects)
    {
        foreach (Rigidbody obj in objects)
        {
            obj.useGravity = false;
        }
    }
}
