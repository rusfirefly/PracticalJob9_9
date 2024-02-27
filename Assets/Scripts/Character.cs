using System;
using UnityEngine;


public class Character : MonoBehaviour
{
    public static event Action AttackEvent;
    [SerializeField] private CharacterView _charaterView;
    [SerializeField] private Transform _hand;



    public void Attack()
    {
        _charaterView.Attack();
        AttackEvent?.Invoke();
    }

    public void StartRun()
    {
        _charaterView.Run();
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
