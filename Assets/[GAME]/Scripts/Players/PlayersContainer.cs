using UnityEngine;
using Zenject;

public class PlayersContainer : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Transform _enemySpawnPoint;
    // test
    [SerializeField] private bool _isSpawning = false;
    [SerializeField] private bool _isWork = false;
    [SerializeField] private Unit _unitPrefab;

    private Level _level;
    private EnemyAI _enemyAI;
    private TowerCreator _сreator;
    private PlayerData _playerData;
    private MainTower _towerPrefab;

    private MainTower _playerTower;
    private MainTower _enemyTower;

    private Vector3 _enemyTowerRotation = new Vector3 (0, 180f, 0);

    public Player Player { get; private set; }

    [Inject]
    private void Construct(MainTower towerPrefab, Level level, EnemyAI enemyAI, Player player, PlayerData playerData)
    {
        _towerPrefab = towerPrefab;
        _level = level;
        _enemyAI = enemyAI;
        Player = player;
        _playerData = playerData;
    }

    public void Init(LevelVisualConfig levelVisualConfig, LevelBalanceConfig levelBalanceConfig, LevelEraConfig levelEraConfig)
    {
        _сreator = new TowerCreator();

        InitPlayerTower(levelEraConfig);
        InitEnemyTower(levelVisualConfig, levelBalanceConfig);

        Player.Init(_playerTower, _enemyTower, _playerData, levelEraConfig);
        _enemyAI.Init(_enemyTower, _playerTower, levelBalanceConfig);
    }

    public void Activate()
    {
        _enemyAI.Activate();
    }

    public void Deactivate()
    {
        _enemyAI.Deactivate();
    }

    private void InitPlayerTower(LevelEraConfig levelEraConfig)
    {
        var eraIndex = _playerData.Load();
        _playerTower = _сreator.Create(levelEraConfig.UnitsPacks[eraIndex - 1].MainTower, this.transform);
        _playerTower.transform.position = _playerSpawnPoint.position;
    }

    private void InitEnemyTower(LevelVisualConfig levelVisualConfig, LevelBalanceConfig levelBalanceConfig)
    {
        _enemyTower = _сreator.Create(levelVisualConfig.EnemyTowers[_level.CurrentLevel - 1].TowerPrefab, this.transform);
        _enemyTower.Init(levelVisualConfig.EnemyTowers[_level.CurrentLevel - 1].Health, PlayerType.Red);
        _enemyTower.transform.position = _enemySpawnPoint.position;
        _enemyTower.transform.rotation = Quaternion.Euler(_enemyTowerRotation); 
    }

    private void Update()
    {
        if (_isSpawning == true && _isWork == false)
        {
            _isWork = true;
            Player.SpawnUnit(_unitPrefab);
        }
        else if (_isWork && _isSpawning ==false)
        {
            _isWork = false;
        }
    }
}