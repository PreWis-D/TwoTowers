using UnityEngine;
using Zenject;

public class PlayersInstaller : MonoInstaller
{
    [SerializeField] private PlayersContainer _playersContainer;
    [SerializeField] private MainTower _towerPrefab;

    public override void InstallBindings()
    {
        BindPlayer();
        BindCharactersContainer();
        BindEnemyAI();
    }

    private void BindPlayer()
    {
        Container.Bind<MainTower>()
            .FromInstance(_towerPrefab)
            .AsSingle()
            .NonLazy();
    }

    private void BindCharactersContainer()
    {
        Container.Bind<PlayersContainer>()
            .FromInstance(_playersContainer)
            .AsSingle()
            .NonLazy();
    }

    private void BindEnemyAI()
    {
        Container.Bind<EnemyAI>()
            .FromNew()
            .AsSingle()
            .NonLazy();
    }
}