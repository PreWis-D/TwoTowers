using System;
using UnityEngine;

public class PlayerBalance
{
    private int _currentLevelMoney = 0;
    private const string SAVED_MONEY = "MoneySaveID";

    public event Action<int> MoneyChanged;

    public int CurrentMoney {get; private set;}

    public PlayerBalance()
    {
        _currentLevelMoney = CurrentMoney;
        PullEventMoney();
    }

    public void SaveMoney()
    {
        PlayerPrefs.SetInt(SAVED_MONEY, CurrentMoney);
    }

    public void LoadMoney()
    {
        CurrentMoney = PlayerPrefs.GetInt(SAVED_MONEY, 0);
    }

    public void PullEventMoney()
    {
        MoneyChanged?.Invoke(_currentLevelMoney);
    }

    public void AddLevelMoney(int value, bool isShow = true)
    {
        if (value < 0)
            throw new ArgumentException();

        ChangeMoneyBalance(value, isShow);
    }

    public bool TryRemoveMoney(int value, bool isShow = true)
    {
        if (value < 0)
            throw new ArgumentException();

        if (_currentLevelMoney >= value)
        {
            ChangeMoneyBalance(-value, isShow);
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetCurrentBalance()
    {
        return _currentLevelMoney - CurrentMoney;
    }

    private void ChangeMoneyBalance(int value, bool isShow = true)
    {
        _currentLevelMoney += value;
        if (isShow == false)
            SaveMoney();

        if (isShow)
            PullEventMoney();
    }
}
