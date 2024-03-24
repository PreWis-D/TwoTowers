using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitItem : MonoBehaviour
{
    [SerializeField] private Image _unitIcon;
    [SerializeField] private Image _deactivateIcon;
    [SerializeField] private TMP_Text _priceText;

    private Button _buyButton;
    private bool _isActivated = true;
    private Unit _unit;
    private int _price;

    public event Action<Unit, int> UnitBuyed;

    public void Init(Unit unit)
    {
        _buyButton = GetComponent<Button>();

        _unit = unit;
        _price = _unit.Properties.Price;
        _unitIcon.sprite = _unit.Properties.Icon;

        _priceText.text = _price.ToString();

        _buyButton.onClick.AddListener(OnBuyButtonClicked);

        CheckFood(0);
    }

    private void OnBuyButtonClicked()
    {
        UnitBuyed?.Invoke(_unit, _price);
    }

    public void CheckFood(int balance)
    {
        if (balance >= _price && _isActivated == false)
        {
            _isActivated = true;
            _buyButton.interactable = true;
            _deactivateIcon.gameObject.SetActive(false);
            _priceText.color = Color.white;
        }
        else if (balance < _price && _isActivated == true)
        {
            _isActivated = false;
            _buyButton.interactable = false;
            _deactivateIcon.gameObject.SetActive(true);
            _priceText.color = Color.red;
        }
    }

    private void OnDestroy()
    {
        if (_buyButton)
            _buyButton.onClick.RemoveListener(OnBuyButtonClicked);
    }
}