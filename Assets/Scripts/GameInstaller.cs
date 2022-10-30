using Base;
using Services;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private Configuration _configuration;
    
    public override void InstallBindings()
    {
        Container.Bind<IActorsService>().FromInstance(new ActorsService()).AsSingle();
        Container.Bind<IHealthService>().FromInstance(new HealthService()).AsSingle();
        Container.Bind<Configuration>().FromInstance(_configuration).AsSingle();
    }
}