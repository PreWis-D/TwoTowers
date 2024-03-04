using UnityEngine;

public class PlayerCreator : CharactersCreator
{
    public override T Create<T>(T prefab, Transform parent)
    {
        var player = Object.Instantiate(prefab, parent);
        return player;
    }
}