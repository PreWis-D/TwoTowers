using UnityEngine;
using UnityEngine.AI;

public abstract class Character : MonoBehaviour
{
    protected CharacterMover CharacterMover;

    public NavMeshAgent NavMeshAgent { get; private set; }

    protected void Init()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();

        CharacterMover = new CharacterMover(this);
    }

    public void Activate()
    {
        CharacterMover.Activate();
    }

    public void Deactivate()
    {
        CharacterMover.Deactivate();
    }
}