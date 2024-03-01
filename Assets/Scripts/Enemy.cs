
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyView _enemyView;
    [SerializeField] private RagdollHandler _ragdollHandler;
    [SerializeField] private Mover _mover;
    private bool _isDie;
    private float _currentTime;
    private float _timeStartStandUp = 3f;

    private void Awake()
    {
        _enemyView.Initialized(transform);
        _ragdollHandler.Initialized();
        StartRun();
    }

    private void Update()
    {
        bool isGround = _enemyView.IsGround();
        if(_isDie && isGround)
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= _timeStartStandUp)
            {
                _enemyView.ShowName();
                StandUP();
                _currentTime -= _timeStartStandUp;
                _isDie = false;
            }
        }
    }

    private void OnEnable()
    {
        _enemyView.StandUp += OnStandUp;
    }

    private void OnDisable()
    {
        _enemyView.StandUp -= OnStandUp;
    }

    public void Kill()
    {
        _enemyView.HideName();
        _enemyView.DisableAnimator();
        _mover.Disable();
        _ragdollHandler.Enable();
        _ragdollHandler.OffGravity();

        _isDie = true;
        _currentTime = 0;
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
        _enemyView.HideName();
        _enemyView.DisableAnimator();
        _mover.Disable();
        _ragdollHandler.Enable();

        _ragdollHandler.Hit(force, hitPosition);
        _isDie = true;
        _currentTime = 0;
    }

    private void OnStandUp()
    {
        StartRun();
    }

    
}
