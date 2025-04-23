using CommonScene.Scripts;
using Configs.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneMainMenu.Scripts
{
    public class MainMenuController : MonoBehaviour, ISceneSPI
    {
        [SerializeField]
        private SceneConfig sceneConfig;
        
        public string GetSceneName()
        {
            return "SceneMainMenu";
        }
        
        public void OnPlayClicked()
        {
            SceneManager.LoadScene(sceneConfig.characterSelection);
        }
        
    }
}