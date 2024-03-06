using UnityEngine;

public abstract class Creator
{
    public abstract T Create<T>(T prefab, Transform parent) where T : MonoBehaviour;
}