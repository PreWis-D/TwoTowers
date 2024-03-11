using UnityEngine;

public class Player : Character, IFollower
{
    private IInput _input;

    public Transform Transform => transform;

    public void Init(IInput input)
    {
        Init();

        CharacterMover = new CharacterMover(this);

        _input = input;
    }

    private void Update()
    {
        if (_input.Direction != Vector3.zero) CharacterMover.StartMove(_input.Direction);
        else CharacterMover.StopMove();
    }
}