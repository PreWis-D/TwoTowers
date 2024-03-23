using UnityEngine;
using Zenject;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private LevelVisualConfig _visualConfig;
    [SerializeField] private LevelBalanceConfig _balanceConfig;

    private Level _level;
    private PlayersContainer _charactersContainer;
    private PlayerInput _playerInput;

    [Inject]
    private void Construct(Level level, PlayersContainer charactersContainer, PlayerInput playerInput)
    {
        _level = level;
        _charactersContainer = charactersContainer;
        _playerInput = playerInput;
    }

    public void Start()
    {
        _level.Init(_visualConfig, _balanceConfig);
        _charactersContainer.Init(_visualConfig, _balanceConfig);

        _playerInput.Enable();

        _level.Start();
    }
}