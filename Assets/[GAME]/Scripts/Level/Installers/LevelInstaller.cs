using System;
using Zenject;
using UnityEngine;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private CamerasHolder _camerasHolder;

    public override void InstallBindings()
    {
        BindCamerasHolder();
        BindLevel();
        BindAudio();
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
}