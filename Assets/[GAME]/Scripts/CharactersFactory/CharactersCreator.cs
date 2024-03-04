using UnityEngine;

public abstract class CharactersCreator
{
    public abstract T Create<T>(T prefab, Transform parent) where T : MonoBehaviour;
}