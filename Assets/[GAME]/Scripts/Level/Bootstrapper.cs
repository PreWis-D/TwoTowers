using UnityEngine;
using Zenject;

public class Bootstrapper : MonoBehaviour
{
    private Level _level;
    private CamerasHolder _camerasHolder;
    private CharactersContainer _charactersContainer;

    [Inject]
    private void Construct(Level level, CamerasHolder camerasHolder, CharactersContainer charactersContainer)
    {
        _level = level;
        _camerasHolder = camerasHolder;
        _charactersContainer = charactersContainer;
    }

    public void Start()
    {
        _level.Init();
        _camerasHolder.Init();
        _charactersContainer.Init();
    }
}