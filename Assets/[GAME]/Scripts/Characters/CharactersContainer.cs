﻿using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharactersContainer : MonoBehaviour
{
    private CharacterCreator _playerCreator;

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
        _playerCreator = new CharacterCreator();

        _player = _playerCreator.Create(_playerPrefab, this.transform);
    }
}