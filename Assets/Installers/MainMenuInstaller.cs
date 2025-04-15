using CommonScene;
using SceneMainMenu;
using Zenject;
using UnityEngine;

namespace Installers
{
    public class MainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISceneSPI>()
                .WithId("SceneMainMenu")
                .To<MainMenuController>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}