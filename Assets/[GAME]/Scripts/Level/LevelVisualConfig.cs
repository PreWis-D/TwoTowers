using UnityEngine;

[CreateAssetMenu(fileName = "LevelVisualConfig", menuName = "Configs/LevelVisualConfig")]
public class LevelVisualConfig : ScriptableObject
{
    [SerializeField] private Transform[] _environments;
    [SerializeField] private TowerProperties[] _enemyTowers;

    public Transform[] Environments => _environments;
    public TowerProperties[] EnemyTowers => _enemyTowers;
}