public class Player
{
    private PlayerData _playerData;
    private MainTower _mainTowerBlue;
    private MainTower _mainTowerRed;
    private int _counter = 0;

    public int CurrentEra {  get; private set; }
    public int CurrentStage { get; private set; }
    public float FoodAddDuration { get; private set; }

    public void Init(MainTower mainTower, MainTower enemyTower, PlayerData playerData, LevelEraConfig levelEraConfig)
    {
        _mainTowerBlue = mainTower;
        _mainTowerRed = enemyTower;
        _playerData = playerData;

        CurrentEra = _playerData.Load();
        CurrentStage = _playerData.LoadStage();
        FoodAddDuration = _playerData.LoadDuration();

        _mainTowerBlue.Init(50, PlayerType.Blue);
    }

    public void SpawnUnit(Unit unitPrefab)
    {
        var unit = UnityEngine.Object.Instantiate(unitPrefab);
        unit.transform.position = _mainTowerBlue.SpawnPoints[_counter].position;
        unit.transform.rotation = _mainTowerBlue.transform.rotation;
        unit.Init(_mainTowerBlue.PlayerType, _mainTowerRed);
        unit.Activate();

        _counter++;
        if (_counter >= _mainTowerBlue.SpawnPoints.Length) _counter = 0;
    }
}