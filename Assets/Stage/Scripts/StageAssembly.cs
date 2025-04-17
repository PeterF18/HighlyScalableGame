using Common.Scripts;
using CommonStage.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Stage.Scripts
{
    [CreateAssetMenu(menuName = "Stage/StageAssembly")]
    public class StageAssembly : SPILoaderBase
    {
        [SerializeField] private string sceneName;
        
        public override object CreateAndBind(DiContainer container)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            var stageImpl = FindObjectsByType<StageClassic>();
            container.Bind<StageSPI>().FromInstance(stageImpl).AsSingle();
            
            return stageImpl;
        }
    }
}