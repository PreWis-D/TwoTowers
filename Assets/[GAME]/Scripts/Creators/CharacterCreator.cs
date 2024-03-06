using UnityEngine;

public class CharacterCreator : Creator
{
    public override T Create<T>(T prefab, Transform parent)
    {
        var player = Object.Instantiate(prefab, parent);
        return player;
    }
}