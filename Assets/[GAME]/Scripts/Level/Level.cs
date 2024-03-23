using Zenject;

public class Level
{
    private LevelVisualConfig _levelConfig;
    private LevelBalanceConfig _levelBalance;
    private AudioController _controller;
    private LevelData _levelData;
    private PlayersContainer _playersContainer;

    public int CurrentLevel { get; private set; }

    [Inject]
    public void Construct(AudioController audioController, LevelData levelData, PlayersContainer playersContainer)
    {
        _controller = audioController;
        _levelData = levelData;
        _playersContainer = playersContainer;
    }

    public void Init(LevelVisualConfig levelConfig, LevelBalanceConfig levelBalanceConfig)
    {
        _levelConfig = levelConfig;
        _levelBalance = levelBalanceConfig;

        CurrentLevel = _levelData.Load();

        UnityEngine.Object.Instantiate(_levelConfig.Environments[CurrentLevel - 1]);
    }

    public void Start()
    {
        _playersContainer.Activate();
    }
}