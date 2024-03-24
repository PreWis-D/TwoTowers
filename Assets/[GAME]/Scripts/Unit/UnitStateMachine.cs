using Cysharp.Threading.Tasks;
using UnityEngine;

public class UnitStateMachine : IUnitComponent
{
    private UnitBehaviourState _currentState;
    private Unit _unit;
    private DamageHandler _enemy;
    private Transform _lookAt;
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
        _unit.DamageHandler.Died += Die;
    }

    public void Deactivate()
    {
        IsActived = false;
        _unit.DamageHandler.Died -= Die;
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

        if (IsActived == false) return;

        if (_unit.EnemyDetecter.EnemyUnit)
            SetAttackTarget(
                _unit.EnemyDetecter.EnemyUnit.transform
                , _unit.Properties.EnemyUnitAttackDistance
                , _unit.EnemyDetecter.EnemyUnit.DamageHandler);
        else if (_unit.TowerEnemy)
            SetAttackTarget(_unit.TowerEnemy.transform
                , _unit.Properties.TowerAttackDistance
                , _unit.TowerEnemy.DamageHandler);

        _currentState = UnitBehaviourState.Move;
        _unit.ChangeState(_currentState);
    }

    private void SetAttackTarget(Transform target, float attackDistance, DamageHandler damageHandler)
    {
        _unit.SetAttackTarget(target);
        _attackDistance = attackDistance;
        _enemy = damageHandler;
        _lookAt = target;
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
            _unit.transform.LookAt(_lookAt);
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
        if (_enemy.CurrentHealth > 0) return;

        _currentState = UnitBehaviourState.Idle;
        _unit.ChangeState(_currentState);
    }
    #endregion

    #region Die
    private void Die()
    {
        if (_currentState == UnitBehaviourState.Die) return;

        _currentState = UnitBehaviourState.Die;
        _unit.ChangeState(_currentState);
    }
    #endregion
}