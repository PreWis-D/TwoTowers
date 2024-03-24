using Cysharp.Threading.Tasks;

public class EnemyAI
{
    private MainTower _mainTowerRed;
    private MainTower _mainTowerBlue;
    private LevelBalanceConfig _balanceConfig;

    private bool _isActivate;
    private int _counterWaves = 0;

    public void Init(MainTower mainTowerRed, MainTower mainTowerBlue,  LevelBalanceConfig balanceConfig)
    {
        _mainTowerRed = mainTowerRed;
        _mainTowerBlue = mainTowerBlue;
        _balanceConfig = balanceConfig;
    }

    public void Activate()
    {
        _isActivate = true;
        SpawnUnits().Forget();
    }

    public void Deactivate()
    {
        _isActivate = false;
    }

    private async UniTaskVoid SpawnUnits()
    {
        while (_isActivate)
        {
            if (_counterWaves >= _balanceConfig.EnemiesWaves.Length)
            {
                _isActivate = false;
                return;
            }

            await UniTask.Delay((int)_balanceConfig.EnemiesWaves[_counterWaves].DelayStart * 1000);

            for (int i = 0; i < _balanceConfig.EnemiesWaves[_counterWaves].Propirties.Length; i++)
            {
                for (int j = 0; j < _balanceConfig.EnemiesWaves[_counterWaves].Propirties[i].Count; j++)
                {
                    var unit = UnityEngine.Object.Instantiate(_balanceConfig.EnemiesWaves[_counterWaves].Propirties[i].UnitPrefab);
                    unit.transform.position = _mainTowerRed.SpawnPoints[j].position;
                    unit.transform.rotation = _mainTowerRed.transform.rotation;
                    unit.Init(_mainTowerRed.PlayerType, _mainTowerBlue);
                    unit.Activate();
                }
            }
            _counterWaves++;
        }
    }
}