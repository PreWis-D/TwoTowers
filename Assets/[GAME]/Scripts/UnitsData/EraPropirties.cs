using System;
using UnityEngine;

[Serializable]
public struct EraPropirties
{
    [SerializeField] private Unit[] _units;
    [SerializeField] private MainTower _mainTower;

    public Unit[] Units => _units; 
    public MainTower MainTower => _mainTower;
}