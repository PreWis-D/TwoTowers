using System;
using UnityEngine;

[Serializable]
public class UnitAnimator : IUnitComponent
{
    [SerializeField] private Animator _animator;

    private Unit _unit;

    private int _hashIsMove = Animator.StringToHash("Move");
    private int _hashIsAttack = Animator.StringToHash("Attack");
    private int _hashIsDie = Animator.StringToHash("Die");

    public bool IsActived { get; private set; }

    public void Init(Unit unit)
    {
        _unit = unit;
    }

    public void Activate()
    {
        IsActived = true;
    }

    public void Deactivate()
    {
        IsActived = false;
    }

    public void Idle()
    {
        _animator.SetBool(_hashIsMove, false);
        _animator.SetBool(_hashIsAttack, false);
    }

    public void Move()
    {
        _animator.SetBool(_hashIsMove, true);
    }

    public void Attack()
    {
        _animator.SetBool(_hashIsAttack, true);
    }

    public void Die()
    {
        _animator.SetTrigger(_hashIsDie);
    }
}