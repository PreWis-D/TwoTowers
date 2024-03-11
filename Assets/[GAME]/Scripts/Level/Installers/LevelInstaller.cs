using Zenject;
using UnityEngine;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private CamerasHolder _camerasHolder;
    [SerializeField] private JoystickInput _joystickInputPrefab;

    public override void InstallBindings()
    {
        BindCamerasHolder();
        BindLevel();
        BindAudio();
        BindPlayerInput();
    }

    private void BindCamerasHolder()
    {
        Container.Bind<CamerasHolder>()
            .FromInstance(_camerasHolder)
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

        Container.Bind<IInput>()
            .To<JoystickInput>()
            .FromComponentInNewPrefab(_joystickInputPrefab)
            .AsSingle();
    }
}