using Zenject;

public class Level
{
    private LevelVisualConfig _levelConfig;
    private LevelBalanceConfig _levelBalance;
    private AudioController _controller;
    private LevelData _levelData;
    private PlayersContainer _playersContainer;
    private UIHandler _uiHandler;

    public int CurrentLevel { get; private set; }

    [Inject]
    public void Construct(AudioController audioController, LevelData levelData, PlayersContainer playersContainer)
    {
        _controller = audioController;
        _levelData = levelData;
        _playersContainer = playersContainer;
    }

    public void Init(LevelVisualConfig levelConfig, LevelBalanceConfig levelBalanceConfig, UIHandler uIHandler)
    {
        _levelConfig = levelConfig;
        _levelBalance = levelBalanceConfig;
        _uiHandler = uIHandler;

        CurrentLevel = _levelData.Load();

        UnityEngine.Object.Instantiate(_levelConfig.Environments[CurrentLevel - 1]);
    }

    public void Start()
    {
        _uiHandler.StartLevel();
    }

    public void StartBattle()
    {
        _playersContainer.Activate();
    }
}