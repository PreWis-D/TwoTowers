using Zenject;

public class LevelInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindLevelData();
        BindLevel();
        BindAudio();
        BindPlayerInput();
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
}