using System;
using UnityEngine;

[Serializable]
public class BattlePanel : BasePanel
{
    [SerializeField] private FoodCounter _foodCounter;
    [SerializeField] private UnitItemsContainer _unitItemsContainer;

    private Player _player;

    public event Action<Unit> UnitBuyed;

    public void Init(Player player, LevelEraConfig levelEraConfig)
    {
        _player = player;
        _foodCounter.Init(_player.FoodAddDuration);
        _unitItemsContainer.Init(_player, _foodCounter, levelEraConfig);

        _unitItemsContainer.UnitBuyed += OnUnitBuyed;
    }

    private void OnUnitBuyed(Unit unit)
    {
        UnitBuyed?.Invoke(unit);
    }

    public void Activate()
    {
        _foodCounter.Activate();
    }

    public void Deactivate()
    {
        _foodCounter.Deactivate();
    }
}