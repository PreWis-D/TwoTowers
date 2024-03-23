using UnityEngine;
using Zenject;

public class UIHandler : MonoBehaviour
{
    private Level _level;

    [Inject]
    private void Construct(Level level)
    {
        _level = level;
    }
}