using Common.Scripts;
using CommonStage.Scripts;
using UnityEngine;
using Zenject;

namespace Stage.Scripts
{
    [CreateAssetMenu(menuName = "Stage/StageClassic")]
    public class StageAssembly : SPILoaderBase
    {
        [SerializeField] private GameObject stagePrefab;
        
        public override object CreateAndBind(DiContainer container)
        {
            var instance = container.InstantiatePrefab(stagePrefab);
            var spi = instance.GetComponent<StageSPI>();

            if (spi == null)
            {
                Debug.LogError("[Stage] Prefab does not implement StageSPI");
                return null;
            }
            
            Debug.Log("[StageAssembly] We got this far");
            container.Bind<StageSPI>().FromInstance(spi).AsSingle();
            return spi;
        }
    }
}