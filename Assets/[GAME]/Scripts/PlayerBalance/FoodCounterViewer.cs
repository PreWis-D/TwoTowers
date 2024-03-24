using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class FoodCounterViewer
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _foodText;

    private FoodCounter _foodCounter;
    private float _duration;

    public void Init(FoodCounter foodCounter, float duration)
    {
        _foodCounter = foodCounter;
        _duration = duration;

        _foodCounter.EstimateChanged += OnEstimateChanged;
        _foodCounter.FoodCountChanged += OnFoodCountChanged;
    }

    private void OnFoodCountChanged(int value)
    {
        _foodText.text = value.ToString();
    }

    private void OnEstimateChanged(float value)
    {
        _image.fillAmount = value / _duration;
    }

    public void OnDestroy()
    {
        _foodCounter.EstimateChanged -= OnEstimateChanged;
        _foodCounter.FoodCountChanged -= OnFoodCountChanged;
    }
}