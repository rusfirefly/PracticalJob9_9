using System;
using UnityEngine;


public class Character : MonoBehaviour
{
    public static event Action<bool> AttackEvent;
    [SerializeField] private CharacterView _charaterView;

    public void Attack()
    {
        _charaterView.Attack();
    }

    public void AttackStartEvent()
    {
        AttackEvent?.Invoke(true);
    }

    public void StartRun()
    {
        _charaterView.Run();
    }

    public void StopAttack()
    {
        AttackEvent?.Invoke(false);
    }

    public void Blend(float speed)
    {
        _charaterView.Blend(speed);
    }

    public void Idle()
    {
        _charaterView.Idle();
    }
}
