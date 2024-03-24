using System;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class UnitMover : IUnitComponent
{
    [SerializeField] private NavMeshAgent _agent;

    private Unit _unit;

    public bool IsActived { get; private set; }

    public void Init(Unit unit)
    {
        _unit = unit;

        _agent.speed = _unit.Properties.Speed;
    }

    public void Activate()
    {
        IsActived = true;
        _agent.enabled = IsActived;
    }

    public void Deactivate()
    {
        IsActived = false;
        _agent.enabled = IsActived;
    }

    public void StopMove()
    {
        if (_agent.enabled && _agent.isStopped == false)
        {
            _agent.isStopped = true;
        }
    }

    public void Move(Vector3 targetPosition)
    {
        if (_agent.enabled)
        {
            if (_agent.isStopped)
                _agent.isStopped = false;

            _agent.SetDestination(targetPosition);
        }
    }
}