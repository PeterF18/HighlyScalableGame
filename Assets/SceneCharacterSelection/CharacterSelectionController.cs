using CommonScene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneCharacterSelection
{
    public class CharacterSelectionController : MonoBehaviour, ISceneSPI
    {
        public string GetSceneName()
        {
            return "SceneCharacterSelection";
        }
        
        public void OnNextClicked()
        {
            SceneManager.LoadScene("SceneStageSelection");
        }
        
    }
}