using UnityEngine;
using UnityEngine.AI;

public class CharacterMover
{
    private Character _character;
    private NavMeshAgent _agent;

    public CharacterMover(Character character)
    {
        _character = character;

        _agent = _character.NavMeshAgent;
    }

    public void Activate()
    {
        _agent.enabled = true;
    }

    public void Deactivate()
    {
        _agent.enabled = false;
    }

    public void StopMove()
    {
        if (_agent.enabled && _agent.isStopped == false)
            _agent.isStopped = true;
    }

    public void StartMove(Vector3 targetPosition)
    {
        if (_agent.enabled)
        {
            if (_agent.isStopped)
                _agent.isStopped = false;

            _agent.SetDestination(targetPosition);
        }
    }
}