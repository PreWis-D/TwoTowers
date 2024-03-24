using System;

public class DamageHandler : IDamageble
{
    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }

    public event Action DamageTaked;
    public event Action Died;

    public DamageHandler(int maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth < 1)
            DamageTaked?.Invoke();
        else
            Died?.Invoke();
    }
}
