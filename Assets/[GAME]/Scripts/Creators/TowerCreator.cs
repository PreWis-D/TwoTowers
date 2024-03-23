using UnityEngine;

public class TowerCreator : Creator
{
    public override T Create<T>(T towerPrefab, Transform parent)
    {
        var tower = Object.Instantiate(towerPrefab, parent);
        return tower;
    }
}