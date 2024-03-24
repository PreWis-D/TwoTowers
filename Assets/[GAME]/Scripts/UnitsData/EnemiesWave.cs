using System;
using UnityEngine;

[Serializable]
public struct EnemiesWave
{
    [SerializeField] private EnemiesWavePropirty[] _propirties;
    [SerializeField] private float _delayStart;
    
    public EnemiesWavePropirty[] Propirties => _propirties;
    public float DelayStart => _delayStart;
}

[Serializable]
public struct EnemiesWavePropirty
{
    [SerializeField] private Unit _unitPrefab;
    [SerializeField] private int _count;

    public Unit UnitPrefab => _unitPrefab;
    public int Count => _count;
}