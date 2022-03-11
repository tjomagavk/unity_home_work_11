using System.Collections.Generic;
using UnityEngine;
using WildBall.Mechanism;
using Zenject;

namespace WildBall.GlobalController
{
    public class WinManagerInstaller : MonoInstaller
    {
        [SerializeField] private List<KeyPoint> keyPoints;
        [SerializeField] private ParticleSystem rocket;
        [SerializeField] private bool finalLevel;

        public override void InstallBindings()
        {
            Container.Bind<WinManager>()
                .FromNew()
                .AsSingle()
                .WithArguments(keyPoints, rocket, finalLevel)
                .NonLazy();
        }
    }
}