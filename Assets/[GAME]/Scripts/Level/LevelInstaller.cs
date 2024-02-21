using System;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindLevel();
        BindAudio();
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
}