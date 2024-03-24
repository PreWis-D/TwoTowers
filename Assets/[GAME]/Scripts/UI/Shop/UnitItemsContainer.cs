using System;
using UnityEngine;

public class UnitItemsContainer : MonoBehaviour
{
    [SerializeField] private UnitItem[] _unitItems;

    private FoodCounter _foodCounter;

    public event Action<Unit> UnitBuyed;

    public void Init(Player player, FoodCounter foodCounter, LevelEraConfig levelEraConfig)
    {
        _foodCounter = foodCounter;

        for (int i = 0; i < _unitItems.Length; i++)
        {
            _unitItems[i].UnitBuyed += OnUnitBuyed;

            if (i < player.CurrentStage) _unitItems[i].Init(levelEraConfig.UnitsPacks[player.CurrentEra - 1].Units[i]);
            else _unitItems[i].gameObject.SetActive(false);
        }

        _foodCounter.FoodCountChanged += OnFoodCountChanged;
    }

    private void OnFoodCountChanged(int value)
    {
        CheckFood();
    }

    private void OnUnitBuyed(Unit unit, int price)
    {
        UnitBuyed?.Invoke(unit);

        _foodCounter.RemoveFoodCount(price);

        CheckFood();
    }

    private void CheckFood()
    {
        for (int i = 0; i < _unitItems.Length; i++)
        {
            if (_unitItems[i].gameObject.activeSelf)
                _unitItems[i].CheckFood(_foodCounter.FoodCount);
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _unitItems.Length; i++)
            _unitItems[i].UnitBuyed -= OnUnitBuyed;

        _foodCounter.FoodCountChanged -= OnFoodCountChanged;
    }
}