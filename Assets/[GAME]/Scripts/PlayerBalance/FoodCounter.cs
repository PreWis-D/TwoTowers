using System;
using UnityEngine;

public class FoodCounter : MonoBehaviour
{
    [SerializeField] private FoodCounterViewer _foodCounterViewer;

    private bool _isActivated;
    private float _duration;
    private float _estimateTime = 0;

    public int FoodCount { get; private set; } = 0;

    public event Action<float> EstimateChanged;
    public event Action<int> FoodCountChanged;

    public void Init(float duration)
    {
        _duration = duration;

        _foodCounterViewer.Init(this, _duration);
    }

    public void Activate()
    {
        _isActivated = true;
    }

    public void Deactivate()
    {
        _isActivated = false;
    }

    public void RemoveFoodCount(int value)
    {
        FoodCount -= value;

        if (FoodCount < 0)
            FoodCount = 0;

        FoodCountChanged?.Invoke(FoodCount);
    }

    public void Update()
    {
        if (_isActivated)
        {
            _estimateTime += Time.deltaTime;

            if (_estimateTime >= _duration)
            {
                _estimateTime = 0;
                FoodCount++;
                FoodCountChanged?.Invoke(FoodCount);
            }

            EstimateChanged?.Invoke(_estimateTime);
        }
    }

    private void OnDestroy()
    {
        _foodCounterViewer.OnDestroy();
    }
}