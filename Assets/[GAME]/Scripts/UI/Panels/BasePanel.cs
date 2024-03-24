using UnityEngine;

public abstract class BasePanel
{
    [SerializeField] private Transform _staticPanel;   
    [SerializeField] private Transform _dynamicPanel;
    
    public void Show()
    {
        _staticPanel.gameObject.SetActive(true);
        _dynamicPanel.gameObject.SetActive(true);
    }

    public void Hide()
    {
        _staticPanel.gameObject.SetActive(false);
        _dynamicPanel.gameObject.SetActive(false);
    }
}