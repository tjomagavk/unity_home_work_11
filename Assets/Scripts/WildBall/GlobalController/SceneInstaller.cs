using Zenject;

namespace WildBall.GlobalController
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SceneController>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
    }
}