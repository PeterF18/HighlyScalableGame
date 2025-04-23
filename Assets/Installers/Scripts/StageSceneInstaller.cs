using CommonStage.Scripts;
using Zenject;

namespace Installers.Scripts
{
    public class StageSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IStageSPI>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
        
    }
}