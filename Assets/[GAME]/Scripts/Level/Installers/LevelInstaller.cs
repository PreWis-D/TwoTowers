using Zenject;
using UnityEngine;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private UIHandler _uiHandlerPrefab;

    public override void InstallBindings()
    {
        BindLevelData();
        BindLevel();
        BindAudio();
        BindPlayerInput();
        BindUIHandler();
    }

    private void BindLevelData()
    {
        Container.Bind<LevelData>()
            .FromNew()
            .AsSingle()
            .NonLazy();
    }

    private void BindLevel()
    {
        Container.Bind<Level>()
            .FromNew()
            .AsSingle()
            .NonLazy();
    }

    private void BindAudio()
    {
        Container.Bind<AudioController>()
            .FromNew()
            .AsSingle()
            .NonLazy();
    }

    private void BindPlayerInput()
    {
        Container.Bind<PlayerInput>()
            .FromNew()
            .AsSingle()
            .NonLazy();
    }

    private void BindUIHandler()
    {
        var uiHadler = Container
            .InstantiatePrefabForComponent<UIHandler>(
            _uiHandlerPrefab
            , Vector3.zero
            , Quaternion.identity
            , null);

        Container
            .Bind<UIHandler>()
            .FromInstance(uiHadler)
            .AsSingle();
    }
}