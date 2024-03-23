using System;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class UnitMover : IUnitComponent
{
    [SerializeField] private NavMeshAgent _agent;

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