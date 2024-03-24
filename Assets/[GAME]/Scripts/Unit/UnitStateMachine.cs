using Cysharp.Threading.Tasks;
using UnityEngine;

public class UnitStateMachine : IUnitComponent
{
    private UnitBehaviourState _currentState;
    private Unit _unit;
    private DamageHandler _enemy;
    private float _attackDistance;

    public bool IsActived { get; private set; }

    #region Core
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
    #endregion

    public void Update()
    {
        if (IsActived == false) return;

        switch (_unit.State)
        {
            case UnitBehaviourState.Idle:
                Idle();
                break;
            case UnitBehaviourState.Move:
                Move();
                break;
            case UnitBehaviourState.Attack:
                Attack();
                break;
            case UnitBehaviourState.Die:
                Die();
                break;
        }
    }

    #region Idle
    private async void Idle()
    {
        if (_currentState == _unit.State)
        {
            await SearchAttackTarget();
        }
        else
        {
            _currentState = _unit.State;
            _unit.ChangeState(_currentState);
        }
    }

    private async UniTask SearchAttackTarget()
    {
        await UniTask.Delay(500);

        if (_unit.EnemyDetecter.EnemyUnit)
        {
            _unit.SetAttackTarget(_unit.EnemyDetecter.EnemyUnit.transform);
            _attackDistance = _unit.Properties.EnemyUnitAttackDistance;
            _enemy = _unit.EnemyDetecter.EnemyUnit.DamageHandler;
        }
        else
        {
            _unit.SetAttackTarget(_unit.TowerEnemy.transform);
            _attackDistance = _unit.Properties.TowerAttackDistance;
            _enemy = _unit.TowerEnemy.DamageHandler;
        }

        _currentState = UnitBehaviourState.Move;
        _unit.ChangeState(_currentState);
    }
    #endregion

    #region Move
    private async void Move()
    {
        if (_currentState == _unit.State)
        {
            CheckDistance();
            await SearchAttackTarget();
        }
        else
        {
            _currentState = UnitBehaviourState.Move;
            _unit.ChangeState(_currentState);
        }
    }

    private void CheckDistance()
    {
        if (Vector3.Distance(_unit.transform.position, _unit.Target.position) <= _attackDistance)
        {
            _currentState = UnitBehaviourState.Idle;
            _unit.ChangeState(_currentState);

            _currentState = UnitBehaviourState.Attack;
            _unit.ChangeState(_currentState);
        }
    }
    #endregion

    #region Attack
    private async void Attack()
    {
        if (_currentState == _unit.State)
        {
            CheckAttackTarget();
            await SearchAttackTarget();
        }
        else
        {
            _currentState = UnitBehaviourState.Idle;
            _unit.ChangeState(_currentState);
        }
    }

    private void CheckAttackTarget()
    {

    }
    #endregion

    #region Die
    private void Die()
    {
        if (_currentState == _unit.State) return;

        _currentState = UnitBehaviourState.Die;
        _unit.ChangeState(_currentState);
    }
    #endregion
}