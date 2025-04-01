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

        private void Start()
        {
            string sceneName = _sceneMainMenu.GetSceneName();
            SceneManager.LoadScene(sceneName);
        }
        
    }

}