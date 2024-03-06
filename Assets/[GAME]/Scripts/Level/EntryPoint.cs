using UnityEngine;
using Zenject;

public class EntryPoint : MonoBehaviour
{
    private Level _level;
    private CamerasHolder _camerasHolder;
    private CharactersContainer _charactersContainer;
    private PlayerInput _playerInput;

    [Inject]
    private void Construct(Level level, CamerasHolder camerasHolder, CharactersContainer charactersContainer, PlayerInput playerInput)
    {
        _level = level;
        _camerasHolder = camerasHolder;
        _charactersContainer = charactersContainer;
        _playerInput = playerInput;
    }

    public void Start()
    {
        _level.Init();
        _camerasHolder.Init();
        _charactersContainer.Init();

        _playerInput.Enable();
    }
}