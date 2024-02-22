
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyView _enemyView;
    [SerializeField] private RagdollHandler _ragdollHandler;
    [SerializeField] private Mover _mover;

    private void Awake()
    {
        _enemyView.Initialized();
        _ragdollHandler.Initialized();
        StartRun();
    }

    public void Kill()
    {
        _enemyView.DisableAnimator();
        _ragdollHandler.Enable();
    }

    public void StartRun()
    {
        _enemyView.StartRuning();
        _mover.Enable();
    }

    public void StopRun()
    {
        _enemyView.StopRuning();
        _mover.Disable();
    }

    public void TakeDamage(Vector3 force, Vector3 hitPosition)
    {
        _enemyView.DisableAnimator();
        _mover.Disable();
        _ragdollHandler.Enable();

        _ragdollHandler.Hit(force, hitPosition);
    }
}
