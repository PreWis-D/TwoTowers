using UnityEngine;
using Zenject;

public class PlayersContainer : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Transform _enemySpawnPoint;

    private Level _level;
    private EnemyAI _enemyAI;
    private TowerCreator _сreator;

    private MainTower _towerPrefab;

    private MainTower _playerTower;
    private MainTower _enemyTower;

    private Vector3 _enemyTowerRotation = new Vector3 (0, 180f, 0);

    [Inject]
    private void Construct(MainTower towerPrefab, Level level, EnemyAI enemyAI)
    {
        _towerPrefab = towerPrefab;
        _level = level;
        _enemyAI = enemyAI;
    }

    public void Init(LevelVisualConfig levelVisualConfig, LevelBalanceConfig levelBalanceConfig)
    {
        _сreator = new TowerCreator();

        _playerTower = _сreator.Create(_towerPrefab, this.transform);
        _playerTower.Init(500, PlayerType.Blue);
        _playerTower.transform.position = _playerSpawnPoint.position;

        _enemyTower = _сreator.Create(levelVisualConfig.EnemyTowers[_level.CurrentLevel - 1].TowerPrefab, this.transform);
        _enemyTower.Init(levelVisualConfig.EnemyTowers[_level.CurrentLevel - 1].Health, PlayerType.Red);
        _enemyTower.transform.position = _enemySpawnPoint.position;
        _enemyTower.transform.rotation = Quaternion.Euler(_enemyTowerRotation);

        _enemyAI.Init(_enemyTower, levelBalanceConfig);
    }

    public void Activate()
    {
        _enemyAI.Activate();
    }
}