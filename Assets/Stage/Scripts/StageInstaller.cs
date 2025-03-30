using CommonStage.Scripts;
using UnityEngine;
using Zenject;

namespace Stage.Scripts
{
    public class StageInstaller : MonoInstaller
    {
        [SerializeField] private StageInstallerProvider stageProvider;

        public override void InstallBindings()
        {
            Debug.Log("[StageInstaller] Binding IStageInstallerProvider");
            Container
                .Bind<IStageInstallerProvider>()
                .FromInstance(stageProvider)
                .AsSingle();
        }
        
    }
}