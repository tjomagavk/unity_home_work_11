using UnityEngine;
using WildBall.Player;
using Zenject;

namespace WildBall.GlobalController
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerType playerType;
        [SerializeField] private GameObject playerObject;
        [SerializeField] private GameObject paperPrefab;
        [SerializeField] private GameObject woodPrefab;
        [SerializeField] private ParticleSystem playerFireParticleSystem;
        [SerializeField] private ParticleSystem playerBurnedParticleSystem;

        public override void InstallBindings()
        {
            Container.Bind<PlayerState>()
                .AsSingle()
                .WithArguments(
                    playerType,
                    playerObject,
                    playerFireParticleSystem,
                    playerBurnedParticleSystem,
                    paperPrefab,
                    woodPrefab)
                .NonLazy();
        }
    }
}