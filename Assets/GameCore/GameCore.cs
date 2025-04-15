using CommonScene;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameCore
{
    public class GameCore : MonoBehaviour
    {
        [Inject(Id = "SceneMainMenu")]
        private ISceneSPI _sceneMainMenu;
        
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        
        private void Start()
        {
            SceneManager.LoadScene("SceneMainMenu", LoadSceneMode.Single);
        }
        
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "SceneMainMenu")
            {
                SceneContext sceneContext = FindObjectOfType<SceneContext>();
                if (sceneContext != null)
                {
                    sceneContext.Container.Inject(this);
                    if (_sceneMainMenu != null)
                        Debug.Log("GameCore reinjected, _sceneMainMenu is now: " + _sceneMainMenu.GetSceneName());
                    else
                        Debug.LogError("Reinjection failed: _sceneMainMenu is still null!");
                }
                else
                {
                    Debug.LogError("SceneContext not found in MainMenu scene.");
                }
            }
        }
        
        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

}