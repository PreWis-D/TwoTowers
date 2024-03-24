using UnityEngine;
using Zenject;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private LevelVisualConfig _visualConfig;
    [SerializeField] private LevelBalanceConfig _balanceConfig;
    [SerializeField] private LevelEraConfig _levelEraConfig;

    private Level _level;
    private PlayersContainer _playersContainer;
    private PlayerInput _playerInput;
    private UIHandler _uiHandler;

    [Inject]
    private void Construct(Level level, PlayersContainer charactersContainer, PlayerInput playerInput, UIHandler uIHandler)
    {
        _level = level;
        _playersContainer = charactersContainer;
        _playerInput = playerInput;
        _uiHandler = uIHandler;
    }

    public void Start()
    {
        _level.Init(_visualConfig, _balanceConfig, _uiHandler);
        _playersContainer.Init(_visualConfig, _balanceConfig, _levelEraConfig);
        _uiHandler.Init(_level, _playersContainer, _levelEraConfig);

        _playerInput.Enable();

        _level.Start();
    }
}