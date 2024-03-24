using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class StartPanel : BasePanel
{
    [SerializeField] private Button _battleButton;

    public event Action BattleButtonClicked;

    public void Init()
    {
        _battleButton.onClick.AddListener(OnBattleButtonClicked);
    }

    private void OnBattleButtonClicked()
    {
        BattleButtonClicked?.Invoke();    
    }

    public void OnDestroy()
    {
        _battleButton.onClick.RemoveListener(OnBattleButtonClicked);
    }
}