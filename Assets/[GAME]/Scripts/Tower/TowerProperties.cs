using System;
using UnityEngine;

[Serializable]
public struct TowerProperties
{
    [SerializeField] private MainTower _towerPrefab;
    [SerializeField] private int _health;

    public MainTower TowerPrefab => _towerPrefab;
    public int Health => _health;
}