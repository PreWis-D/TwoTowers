using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharactersContainer : MonoBehaviour
{
    private CharacterCreator _сreator;
    private IInput _input;

    private Player _playerPrefab;
    private Enemy _enemyPrefab;

    private Player _player;
    private List<Enemy> _enemies = new List<Enemy>();

    [Inject]
    private void Construct(Player playerPrefab, Enemy enemyPrefab, IInput input)
    {
        _playerPrefab = playerPrefab;
        _enemyPrefab = enemyPrefab;
        _input = input;
    }

    public void Init()
    {
        _сreator = new CharacterCreator();

        _player = _сreator.Create(_playerPrefab, this.transform);
        _player.Init(_input);
    }
}