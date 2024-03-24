using System;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private bool _isDie;
    [SerializeField] private UnitProperties _properties;
    [SerializeField] private UnitMover _mover;
    [SerializeField] private UnitAnimator _animator;

    private UnitStateMachine _stateMachine;
    private List<IUnitComponent> _components = new List<IUnitComponent>();
    private Collider _collider;

    public UnitProperties Properties => _properties;
    public bool IsDie => _isDie;

    public DamageHandler DamageHandler { get; private set; }
    public UnitEnemyDetecter EnemyDetecter { get; private set; }
    public MainTower TowerEnemy { get; private set; }
    public Transform Target { get; private set; }
    public PlayerType PlayerType { get; private set; }
    public UnitBehaviourState State { get; private set; } = UnitBehaviourState.Idle;

    public void Init(PlayerType playerType, MainTower towerEnemy)
    {
        _collider = GetComponent<Collider>();

        PlayerType = playerType;
        TowerEnemy = towerEnemy;

        _stateMachine = new UnitStateMachine();
        _stateMachine.Init(this);

        EnemyDetecter = new UnitEnemyDetecter();
        EnemyDetecter.Init(this);

        DamageHandler = new DamageHandler(_properties.MaxHealth);

        if (_components.Count == 0)
        {
            _components.Add(_mover);
            _components.Add(_animator);
            _components.Add(_stateMachine);
            _components.Add(EnemyDetecter);
        }

        Subscribe();
    }

    private void Subscribe()
    {
        DamageHandler.DamageTaked += OnDamageTaked;
    }

    private void Unsubscribe()
    {
        DamageHandler.DamageTaked -= OnDamageTaked;
    }

    public void Activate()
    {
        foreach (var component in _components)
            component.Activate();

        _collider.enabled = true;
    }

    public void Deactivate()
    {
        foreach (var component in _components)
            component.Deactivate();
    }

    private void Update()
    {
        EnemyDetecter?.Update();
        _stateMachine?.Update();

        if (_isDie)
        {
            DamageHandler.TakeDamage(1000);
            _isDie = false;
        }
    }

    public void ChangeState(UnitBehaviourState state)
    {
        State = state;

        switch (State)
        {
            case UnitBehaviourState.Idle:
                _mover.StopMove();
                _animator.Idle();
                break;
            case UnitBehaviourState.Move:
                _mover.Move(Target.position);
                _animator.Move();
                break;
            case UnitBehaviourState.Attack:
                _mover.StopMove();
                _animator.Attack();
                break;
            case UnitBehaviourState.Die:
                Deactivate();
                _animator.Die();
                _collider.enabled = false;
                Unsubscribe();
                break;
        }
    }

    public void SetAttackTarget(Transform target)
    {
        Target = target;
    }

    private void OnDamageTaked()
    {
        Debug.Log(DamageHandler.CurrentHealth);
    }
}