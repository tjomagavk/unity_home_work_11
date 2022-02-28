using System.Collections.Generic;
using UnityEngine;
using WildBall.Mechanism;
using Zenject;

namespace WildBall.GlobalController
{
    public class WinManagerInstaller : MonoInstaller
    {
        [SerializeField] private List<KeyPoint> keyPoints;

        public override void InstallBindings()
        {
            Container.Bind<WinManager>()
                .FromNew()
                .AsSingle()
                .WithArguments(keyPoints)
                .NonLazy();
        }
    }
}