using CommonScene;
using Configs;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneMainMenu
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