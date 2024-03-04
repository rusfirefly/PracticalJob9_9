using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterView : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        _animator.SetTrigger("IsAttack");
    }

    public void Blend(float speed)
    {
        _animator.SetFloat("Blend", speed, 0.2f, Time.deltaTime);
    }

    public void Run()
    {
        _animator.SetBool("IsRun", true);
    }

    public void Idle()
    {
        _animator.SetBool("IsRun", false);
    }
}
