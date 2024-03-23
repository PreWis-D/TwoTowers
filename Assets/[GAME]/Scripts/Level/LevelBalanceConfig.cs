using UnityEngine;

[CreateAssetMenu(fileName = "LevelBalanceConfig", menuName = "Configs/LevelBalanceConfig")]
public class LevelBalanceConfig : ScriptableObject
{
    [SerializeField] private EnemiesWave[] _enemiesWaves;

    public EnemiesWave[] EnemiesWaves => _enemiesWaves;
}