using UnityEngine;
using WildBall.Player;
using Zenject;

namespace WildBall.GlobalController
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerType playerType;

        public override void InstallBindings()
        {
            Container.Bind<PlayerState>()
                .AsSingle()
                .WithArguments(playerType)
                .NonLazy();
        }
    }
}