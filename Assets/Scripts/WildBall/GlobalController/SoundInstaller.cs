using UnityEngine;
using Zenject;

namespace WildBall.GlobalController
{
    public class SoundInstaller : MonoInstaller
    {
        [SerializeField] private AudioSource musicSource;

        public override void InstallBindings()
        {
            Container.Bind<SoundManager>()
                .FromNew()
                .AsSingle()
                .WithArguments(musicSource)
                .NonLazy();
        }
    }
}