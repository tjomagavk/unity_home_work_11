using UnityEngine;
using WildBall.UI;
using Zenject;

namespace WildBall.GlobalController
{
    public class GuiInstaller : MonoInstaller
    {
        [SerializeField] private PopupScreen popupScreen;

        public override void InstallBindings()
        {
            Container.Bind<PopupScreen>()
                .FromComponentInNewPrefab(popupScreen)
                .AsSingle()
                .NonLazy();
        }
    }
}