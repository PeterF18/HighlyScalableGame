using CommonScene;
using Configs;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameCore
{
    public class GameCore : MonoBehaviour
    {
        [SerializeField]
        private SceneConfig sceneConfig;
        
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
            SceneContext sceneContext = FindFirstObjectByType<SceneContext>();
        }
        
        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

}