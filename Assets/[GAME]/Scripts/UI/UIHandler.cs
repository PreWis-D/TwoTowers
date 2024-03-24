using System;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private BattlePanel _battlePanel;
    [SerializeField] private StartPanel _startPanel;

    private Level _level;
    private Player _player;

    public void Init(Level level, PlayersContainer playersContainer, LevelEraConfig levelEraConfig)
    {
        _level = level;
        _player = playersContainer.Player;

        _startPanel.Init();
        _battlePanel.Init(_player, levelEraConfig);

        _startPanel.Hide();
        _battlePanel.Hide();

        Subscrube();
    }

    private void Subscrube()
    {
        _startPanel.BattleButtonClicked += OnBattleStarted;
        _battlePanel.UnitBuyed += OnUnitBuyed;
    }

    private void Unsubscribe()
    {
        _startPanel.BattleButtonClicked -= OnBattleStarted;
        _battlePanel.UnitBuyed -= OnUnitBuyed;
    }

    private void OnBattleStarted()
    {
        _level.StartBattle();
        _startPanel.Hide();
        _battlePanel.Show();
        _battlePanel.Activate();
    }

    public void StartLevel()
    {
        _startPanel.Show();
    }

    private void OnUnitBuyed(Unit unit)
    {
        _player.SpawnUnit(unit);
    }

    private void OnDestroy()
    {
        Unsubscribe();
        _startPanel.OnDestroy();
    }
}