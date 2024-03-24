using System;
using UnityEngine;

[Serializable]
public struct UnitProperties
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _damage;
    [SerializeField] private float _towerAttackDistance;
    [SerializeField] private float _enemyUnitAttackDistance;
    [SerializeField] private float _speed;

    public int MaxHealth => _maxHealth;
    public int Damage => _damage;
    public float TowerAttackDistance => _towerAttackDistance;
    public float EnemyUnitAttackDistance => _enemyUnitAttackDistance;
    public float Speed => _speed;
}