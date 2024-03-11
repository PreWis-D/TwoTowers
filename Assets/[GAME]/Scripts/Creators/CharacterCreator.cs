using UnityEngine;

public class CharacterCreator : Creator
{
    public override T Create<T>(T character, Transform parent)
    {
        var player = Object.Instantiate(character, parent);
        return player;
    }
}