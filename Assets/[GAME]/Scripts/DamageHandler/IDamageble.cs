using System;

public interface IDamageble
{
    int MaxHealth { get; }
    int CurrentHealth { get; }

    public event Action DamageTaked;
    public event Action Died;

    void TakeDamage(int damage);   
}