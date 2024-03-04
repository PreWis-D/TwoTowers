using UnityEngine;

public class EnemyCreator : CharactersCreator
{
    public override T Create<T>(T prefab, Transform parent)
    {
        var player = MonoBehaviour.Instantiate(prefab, parent);
        return player;
    }
}
