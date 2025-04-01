using CommonScene;
using SceneCharacterSelection;
using SceneMainMenu;
using Zenject;
using UnityEngine;

namespace Installers
{
    public class SceneBindingsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISceneSPI>()
                .WithId("SceneMainMenu")
                .To<MainMenuController>()
                .AsSingle();

            Container.Bind<ISceneSPI>()
                .WithId("SceneCharacterSelection")
                .To<CharacterSelectionController>()
                .AsSingle();

        }
    }
}