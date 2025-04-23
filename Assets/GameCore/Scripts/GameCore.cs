using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using CommonScene.Scripts;
using Configs.Scripts;

namespace GameCore.Scripts
{
    public class GameCore : MonoBehaviour
    {
        [SerializeField]
        private SceneConfig sceneConfig;
        
        [SerializeField]
        private CharacterConfig characterConfig;
        
        [Inject(Id = "SceneMainMenu")]
        private ISceneSPI _sceneMainMenu;
        
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        
        private void Start()
        {
            SceneManager.LoadScene(sceneConfig.mainMenu, LoadSceneMode.Single);
        }
        
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            var ctx = FindFirstObjectByType<SceneContext>();
            var characterConfig = this.characterConfig;
            var stage = ctx.Container.Resolve<CommonStage.Scripts.IStageSPI>();
            stage.InitializeStage(characterConfig);


        }
        
        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

}