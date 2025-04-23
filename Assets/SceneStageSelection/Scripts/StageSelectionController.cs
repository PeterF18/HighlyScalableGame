using CommonScene.Scripts;
using Configs.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StageSelectionScene.Scripts
{
    public class StageSelectionController : MonoBehaviour, ISceneSPI
    {
        [SerializeField]
        private SceneConfig sceneConfig;
        
        public string GetSceneName()
        {
            return "SceneCharacterSelection";
        }
        
        public void OnNextClicked()
        {
            SceneManager.LoadScene(sceneConfig.stageDojo);
        }
    }
}