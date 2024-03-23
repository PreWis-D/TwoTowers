using System;
using UnityEngine;

[Serializable]
public class UnitAnimator : IUnitComponent
{
    [SerializeField] private Animator _animator;

    private Unit _unit;

    public void Init(Unit unit)
    {
        _unit = unit; 
    }

    public void Activate()
    {
    }

    public void Deactivate()
    {
    }
}