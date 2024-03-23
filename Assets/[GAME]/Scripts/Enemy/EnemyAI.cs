using Cysharp.Threading.Tasks;

public class EnemyAI
{
    private MainTower _mainTower;
    private LevelBalanceConfig _balanceConfig;

    private bool _isActivate;
    private int _counterWaves = 0;

    public void Init(MainTower mainTower, LevelBalanceConfig balanceConfig)
    {
        _mainTower = mainTower;
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
                    unit.transform.position = _mainTower.SpawnPoints[j].position;
                    unit.transform.rotation = _mainTower.transform.rotation;
                }
            }
            _counterWaves++;
        }
    }
}