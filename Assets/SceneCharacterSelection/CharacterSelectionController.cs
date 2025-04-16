using CommonScene;
using Configs;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneCharacterSelection
{
    public class CharacterSelectionController : MonoBehaviour, ISceneSPI
    {
        [SerializeField]
        private SceneConfig sceneConfig;
        
        public string GetSceneName()
        {
            return "SceneCharacterSelection";
        }
        
        public void OnNextClicked()
        {
            SceneManager.LoadScene(sceneConfig.stageSelection);
        }
        
    }
}