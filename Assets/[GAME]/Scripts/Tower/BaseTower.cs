using System;
using UnityEngine;

public abstract class BaseTower : MonoBehaviour
{
    private int _health;
    private int _currenHealth;

    public event Action DamageTaked;
    public event Action Died;

    public PlayerType PlayerType {  get; private set; }

    public void Init(int health, PlayerType playerType)
    {
        _health = health;
        _currenHealth = _health;
        PlayerType = playerType;
    }

    public void TakeDamage(int damage)
    {
        _currenHealth -= damage;

        if (_currenHealth < 1)
            DamageTaked?.Invoke();
        else
            Died?.Invoke();
    }
}