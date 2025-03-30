using System.Collections;
using CommonStage.Scripts;
using UnityEngine;
using Zenject;

namespace GameCore.Scripts
{
    public class ServiceLoader : MonoBehaviour
    {
        [Inject] private IStageInstallerProvider _stageProvider;
        [Inject] private DiContainer _diContainer;

        private IEnumerator Start()
        {
            yield return null; // wait 1 frame to ensure Zenject finishes setup

            var container = ProjectContext.Instance.Container;
            var provider = container.TryResolve<IStageInstallerProvider>();

            if (provider == null)
            {
                Debug.LogError("[ServiceLoader] Still null after 1 frame");
                yield break;
            }

            foreach (var prefab in provider.GetStageInstallerPrefabs())
            {
                Debug.Log($"[ServiceLoader] Instantiating prefab: {prefab.name}");
                var installer = container.InstantiatePrefabForComponent<MonoInstaller>(prefab);
                installer.InstallBindings();
            }
        }

        
    }
}