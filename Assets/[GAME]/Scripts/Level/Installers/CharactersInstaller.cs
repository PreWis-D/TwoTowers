using UnityEngine;
using Zenject;

public class CharactersInstaller : MonoInstaller
{
    [SerializeField] private CharactersContainer _charactersContainer;
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Enemy _enemyPrefab;

    public override void InstallBindings()
    {
        BindPlayer();
        BindEnemy();
        BindCharactersContainer();
    }

    private void BindPlayer()
    {
        Container.Bind<Player>()
            .FromInstance(_playerPrefab)
            .AsSingle()
            .NonLazy();
    }

    private void BindEnemy()
    {
        Container.Bind<Enemy>()
            .FromInstance(_enemyPrefab)
            .AsSingle()
            .NonLazy();
    }

    private void BindCharactersContainer()
    {
        Container.Bind<CharactersContainer>()
            .FromInstance(_charactersContainer)
            .AsSingle()
            .NonLazy();
    }
}