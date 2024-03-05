using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class KeyboardInput : MonoBehaviour, IInput
{
    private PlayerInput _playerInput;
    private Vector3 _direction;

    public Vector3 Direction => new Vector3(_direction.x, _direction.y, 0f);

    [Inject]
    private void Construct(PlayerInput playerInput)
    {
        _playerInput = playerInput;
    }

    private void OnEnable()
    {
        _playerInput.Player.Move.started += OnMovementInput;
        _playerInput.Player.Move.performed += OnMovementInput;
        _playerInput.Player.Move.canceled += OnMovementInput;
    }

    private void OnMovementInput(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();

        _direction.x = direction.x;
        _direction.y = direction.y;
    }

    private void OnDisable()
    {
        _playerInput.Player.Move.started -= OnMovementInput;
        _playerInput.Player.Move.performed -= OnMovementInput;
        _playerInput.Player.Move.canceled -= OnMovementInput;
    }
}
