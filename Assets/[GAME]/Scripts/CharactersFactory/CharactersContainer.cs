using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharactersContainer : MonoBehaviour
{
    private PlayerCreator _playerCreator;
    private EnemyCreator _enemyCreator;

    private Player _playerPrefab;
    private Enemy _enemyPrefab;

    private Player _player;
    private List<Enemy> _enemies = new List<Enemy>();

    [Inject]
    private void Construct(Player playerPrefab, Enemy enemyPrefab)
    {
        _playerPrefab = playerPrefab;
        _enemyPrefab = enemyPrefab;
    }

    public void Init()
    {
        _playerCreator = new PlayerCreator();
        _enemyCreator = new EnemyCreator();

        _player = _playerCreator.Create(_playerPrefab, this.transform);
    }
}