using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    [Header("AnimationIconOption")]
    [SerializeField] private Image _icon;
    [SerializeField] private Vector3 _offsetSize = new Vector3(0.1f, 0.1f, 0.1f);
    [SerializeField] private float _duration = 0.5f;

    private PlayerBalance _playerBalance;
    private SmoothedTextValue _smoothTextValue;
    private int _currentValue = -1;
    private Vector3 _defaultSize = new Vector3(1, 1, 1);
    private bool _isStart = true;

    public Image Icon => _icon;
    public int CurrentValue => _currentValue;

    private void Awake()
    {
        _smoothTextValue = GetComponent<SmoothedTextValue>();
    }

    public void Init(PlayerBalance playerBalance)
    {
        _playerBalance = playerBalance;

        _playerBalance.MoneyChanged += OnNewCountMoney;
        _playerBalance.PullEventMoney();
    }

    public void OnNewCountMoney(int value)
    {
        if (_currentValue == -1)
            _currentValue = value;

        if (_isStart)
            _isStart = false;
        else
            AnimationAddReward();

        _smoothTextValue.StartSmooth(_text, _currentValue, value);
        _currentValue = value;
    }

    private void AnimationAddReward()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_icon.transform.DOScale(_defaultSize - _offsetSize, _duration));
        sequence.Append(_icon.transform.DOScale(_defaultSize + _offsetSize, _duration));
        sequence.Append(_icon.transform.DOScale(_defaultSize, _duration));
    }

    private void OnDestroy()
    {
        _playerBalance.MoneyChanged -= OnNewCountMoney;
    }
}
