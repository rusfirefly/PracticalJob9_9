
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyView _enemyView;
    [SerializeField] private RagdollHandler _ragdollHandler;
    [SerializeField] private Mover _mover;

    private void Awake()
    {
        _enemyView.Initialized(transform);
        _ragdollHandler.Initialized();
        StartRun();
    }

    private void OnEnable()
    {
        EnemyView.StandUp += OnStandUp;
    }

    private void OnDisable()
    {
        EnemyView.StandUp -= OnStandUp;
    }

    public void Kill()
    {
        StopRun();
        _enemyView.DisableAnimator();
        _ragdollHandler.Enable();
    }

    public void StandUP()
    {
        _enemyView.EnableAnimator();
        _ragdollHandler.Disable();
        _enemyView.NewPositionParent();
        _enemyView.StartStandUpAnimation();
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

    private void OnStandUp()
    {
        StartRun();
    }
}
