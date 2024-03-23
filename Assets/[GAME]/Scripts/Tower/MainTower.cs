using UnityEngine;

public class MainTower : BaseTower
{
    [SerializeField] private Transform[] _spawnPoints;

    public Transform[] SpawnPoints => _spawnPoints;
}