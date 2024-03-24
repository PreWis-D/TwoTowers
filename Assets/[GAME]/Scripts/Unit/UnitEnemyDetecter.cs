using System;
using UnityEngine;

public class UnitEnemyDetecter : IUnitComponent
{
    private Unit _unit;

    private float _radius = 10f;

    public Unit EnemyUnit { get; private set; }
    public bool IsActived { get; private set; }

    public void Init(Unit unit)
    {
        _unit = unit;
    }

    public void Activate()
    {
        IsActived = true;
    }

    public void Deactivate()
    {
        IsActived = false;
    }

    public void Update()
    {
        if (IsActived == false) return;

        if (EnemyUnit && EnemyUnit.State == UnitBehaviourState.Die)
        {
            EnemyUnit = null;
        }
        else if (EnemyUnit == null)
        {
            Collider[] colliders = Physics.OverlapSphere(_unit.transform.position, _radius);

            for (int i = 0; i < colliders.Length; i++)
            {
                var unit = colliders[i].transform.GetComponent<Unit>();

                if (unit && unit.PlayerType != _unit.PlayerType)
                {
                    EnemyUnit = unit;
                }
            }
        }
    }
}