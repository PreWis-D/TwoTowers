using UnityEngine;
using Zenject;

public class PlayersInstaller : MonoInstaller
{
    [SerializeField] private PlayersContainer _playersContainer;
    [SerializeField] private MainTower _towerPrefab;

    public override void InstallBindings()
    {
        BindPlayer();
        BindPlayerData();
        BindMainTower();
        BindCharactersContainer();
        BindEnemyAI();
    }

    private void BindPlayer()
    {
        Container.Bind<Player>()
            .FromNew()
            .AsSingle()
            .NonLazy();
    }

    private void BindPlayerData()
    {
        Container.Bind<PlayerData>()
            .FromNew()
            .AsSingle()
            .NonLazy();
    }

    private void BindMainTower()
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