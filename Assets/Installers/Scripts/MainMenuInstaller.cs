using CommonScene.Scripts;
using SceneMainMenu.Scripts;
using Zenject;

namespace Installers.Scripts
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