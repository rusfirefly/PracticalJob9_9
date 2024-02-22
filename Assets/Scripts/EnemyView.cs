using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyView : MonoBehaviour
{
    private Animator _animator;
    private const string _isRuningKey= "IsRuning";

    public void Initialized()
    {
        _animator = GetComponent<Animator>();
    }

    public void EnableAnimator() => _animator.enabled = true;

    public void DisableAnimator() => _animator.enabled = false;

    public void StartRuning() => _animator.SetBool(_isRuningKey, true);

    public void StopRuning() => _animator.SetBool(_isRuningKey, false);

}
